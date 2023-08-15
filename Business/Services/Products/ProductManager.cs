using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos.Products;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Rules;
using Business.BusinessAspects;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Exceptions;
using System.Linq.Expressions;
using Core.Entities.Concrete;
using Core.Utilities.Results.Paging;

namespace Business.Services.Products
{
    public class ProductManager : ServiceBase, IProductService
    {
        private readonly ProductRules _productRules;

        public ProductManager(IServiceProvider serviceProvider, ProductRules productRules) : base(serviceProvider)
        {
            _productRules = productRules;
        }


        [ValidationAspect(typeof(ProductValidator))]
        [SecuredOperation("Product.Add,Admin")]
        [LogAspect(typeof(MssqlDbLogger))]
        public async Task<IDataResult<ProductDto>> AddAsync(ProductDto productDto)
        {
            await _productRules.ProductAlreadyExists(productDto.Code);

            var mapper = _mapper.Map<Product>(productDto);
            await _unitOfWork.ProductRepository.AddAsync(mapper);
            await _unitOfWork.Commit();
            return new SuccessDataResult<ProductDto>(productDto, Messages.ProductAdded);

        }
        [SecuredOperation("Product.Update,Admin")]
        [LogAspect(typeof(MssqlDbLogger))]
        public async Task<IResult> UpdateAsync(ProductDto productDto)
        {
            var oldEntity = await GetByIdAsync(productDto.Id);

            await _productRules.ProductAlreadyExists(productDto.Name);
            productDto.CreatedDate = oldEntity.Data.CreatedDate;

            var mapper = _mapper.Map<Product>(productDto);
            await _unitOfWork.ProductRepository.UpdateAsync(mapper);
            await _unitOfWork.Commit();
            return new SuccessResult(Messages.ProductUpdated);


        }
        [SecuredOperation("Product.Delete,Admin")]
        public async Task<IResult> DeleteAsync(ProductDto productDto)
        {
            var product = await GetByIdAsync(productDto.Id);

            var mapper = _mapper.Map<Product>(product.Data);
            await _unitOfWork.ProductRepository.DeleteAsync(mapper);
            await _unitOfWork.Commit();
            return new SuccessResult(Messages.ProductDeleted);

        }

        [SecuredOperation("Product.List,Admin")]
        [LogAspect(typeof(MssqlDbLogger))]
        public async Task<IDataResult<IEnumerable<ProductListDto>>> GetAllAsync()
        {

            var includes = new Expression<Func<Product, object>>[]
            {
                x => x.Brand,
                x => x.Category,
                x=>x.Color
            };

            var products = await _unitOfWork.ProductRepository.GetListAsync(includeEntities: includes);

            var mapper = _mapper.Map<List<ProductListDto>>(products);
            return new SuccessDataResult<IEnumerable<ProductListDto>>(mapper, Messages.ProductListed);
        }

        [SecuredOperation("Product.List,Admin")]
        public async Task<PaginatedResult<ProductListDto>> GetTableSearch(TableGlobalFilter tableGlobalFilter)
        {
            var includes = new Expression<Func<Product, object>>[]
            {
                x => x.Brand,
                x => x.Category,
                x=>x.Color 
            };

            var products = await _unitOfWork.ProductRepository.GetListForTableSearch(tableGlobalFilter,includes);
          
            var mapped = _mapper.Map<PaginatedResult<ProductListDto>>(products);
            return mapped;
           
        }
        //[SecuredOperation("Product.List,Admin")]
        //[LogAspect(typeof(MssqlDbLogger))]
        //public async Task<IDataResult<IEnumerable<ProductListDto>>> GetAllAsync()
        //{
        //    var result = await _unitOfWork.ProductRepository.GetAllAsync(expression: x => x.Deleted != true,
        //        include: x => x
        //                    .Include(p => p.Brand)
        //                    .Include(p => p.Category)
        //                    .Include(x => x.Color),
        //        //.Include(x => x.Supplier),
        //        selector: x => new ProductListDto
        //        {
        //            Id = x.Id,
        //            Name = x.Name,
        //            Code = x.Code,
        //            BrandName = x.Brand.Name,
        //            CategoryName = x.Category.Name,
        //            ColorName = x.Color.Name,
        //            UnitPrice = x.UnitPrice,
        //            UnitsInStock = x.UnitsInStock,
        //            //SupplierName = x.Supplier.CompanyName,
        //            CreatedDate = x.CreatedDate,
        //            UpdatedDate = x.UpdatedDate,
        //            Deleted = x.Deleted,
        //        },
        //        orderBy: x => x.OrderBy(x => x.Name));

        //    return new SuccessDataResult<IEnumerable<ProductListDto>>(result, Messages.ProductListed);
        //}
        public async Task<IDataResult<IEnumerable<ProductDto>>> GetAllByCategoryIdAsync(Guid categoryId)
        {
            var result = await _unitOfWork.ProductRepository.GetAllAsync(p => p.CategoryId == categoryId);
            var mapper = _mapper.Map<List<ProductDto>>(result);
            return new SuccessDataResult<IEnumerable<ProductDto>>(mapper);
        }

        public async Task<IDataResult<IEnumerable<ProductDto>>> GetByUnitPriceAsync(decimal min, decimal max)
        {
            var result = await _unitOfWork.ProductRepository.GetAllAsync(p => p.UnitPrice >= min && p.UnitPrice <= max);
            var mapper = _mapper.Map<List<ProductDto>>(result);
            return new SuccessDataResult<IEnumerable<ProductDto>>(mapper);
        }

        [SecuredOperation("Product.Get,Admin")]
        public async Task<IDataResult<ProductDto>> GetByIdAsync(Guid productId)
        {
            var result = await _unitOfWork.ProductRepository.GetAsync(br => br.Id == productId);
            if (result == null) throw new BusinessException(Messages.ProductNotFound);

            var mapper = _mapper.Map<ProductDto>(result);
            return new SuccessDataResult<ProductDto>(mapper);
        }

        public async Task<IDataResult<List<ProductDetailDto>>> GetProductDetails()
        {
            var result = await _unitOfWork.ProductRepository.GetProductDetails();
            return new SuccessDataResult<List<ProductDetailDto>>(result);
        }
    }

}
