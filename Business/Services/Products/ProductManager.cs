using AutoMapper;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using Entities.Dtos.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Rules;
using Core.Utilities.Business;
using Microsoft.EntityFrameworkCore;

namespace Business.Services.Products
{
    public class ProductManager : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ProductRules _productRules;

        public ProductManager(IMapper mapper, IUnitOfWork unitOfWork, ProductRules productRules)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _productRules = productRules;
        }


        [ValidationAspect(typeof(ProductValidator))]
        //[SecuredOperation("Product.List")]
        public async Task<IDataResult<ProductDto>> AddAsync(ProductDto productDto)
        {
            IResult result = BusinessRules.Run(await _productRules.ProductAlreadyExists(productDto.Code));
            if (result == null)
            {
                var mapper = _mapper.Map<Product>(productDto);
                await _unitOfWork.ProductRepository.AddAsync(mapper);
                await _unitOfWork.Commit();
                return new SuccessDataResult<ProductDto>(productDto, Messages.ProductAdded);
            }

            return new ErrorDataResult<ProductDto>(result.Message);
        }

        public async Task<IResult> UpdateAsync(ProductDto productDto)
        {
            var product = await GetByIdAsync(productDto.Id);
            if (product.Data != null)
            {
                IResult result = BusinessRules.Run(await _productRules.ProductAlreadyExists(productDto.Name));
                if (result == null)
                {
                    product.Data.Name = productDto.Name;
                    product.Data.Code = productDto.Code;
                    product.Data.UnitPrice = productDto.UnitPrice;
                    product.Data.UnitsInStock = productDto.UnitsInStock;

                    var mapper = _mapper.Map<Product>(product.Data);
                    await _unitOfWork.ProductRepository.UpdateAsync(mapper);
                    await _unitOfWork.Commit();
                    return new SuccessResult(Messages.ProductUpdated);
                }

                return result;
            }
            return product;
        }

        public async Task<IResult> DeleteAsync(ProductDto productDto)
        {
            var product = await GetByIdAsync(productDto.Id);
            if (product.Data != null)
            {
                var mapper = _mapper.Map<Product>(product.Data);
                await _unitOfWork.ProductRepository.DeleteAsync(mapper);
                await _unitOfWork.Commit();
                return new SuccessResult(Messages.ProductDeleted);
            }

            return product;
        }

        public async Task<IDataResult<IEnumerable<ProductListDto>>> GetAllAsync()
        {
            var result = await _unitOfWork.ProductRepository.GetAllAsync(expression: x => x.Deleted != true,
                include: x => x
                                              .Include(p => p.Brand)
                                              .Include(p => p.Category)
                                              .Include(x => x.Color),
                                              //.Include(x => x.Supplier),
                selector: x => new ProductListDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Code = x.Code,
                    BrandName = x.Brand.Name,
                    CategoryName = x.Category.Name,
                    ColorName = x.Color.Name,
                    //SupplierName = x.Supplier.CompanyName,
                    CreatedDate = x.CreatedDate,
                    UpdatedDate = x.UpdatedDate,
                    Deleted = x.Deleted,
                },
                orderBy: x => x.OrderBy(x => x.Name));

            return new SuccessDataResult<IEnumerable<ProductListDto>>(result, Messages.ProductListed);
        }

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

        public async Task<IDataResult<ProductDto>> GetByIdAsync(Guid productId)
        {
            var result = await _unitOfWork.ProductRepository.GetAsync(br => br.Id == productId);
            if (result == null)
            {
                return new ErrorDataResult<ProductDto>(Messages.ProductNotFound);
            }
            var mapper = _mapper.Map<ProductDto>(result);
            return new SuccessDataResult<ProductDto>(mapper);
        }

        public async Task<IDataResult<List<ProductDetailDto>>> GetProductDetails()
        {
            var result = await _unitOfWork.ProductRepository.GetProductDetails();
            return new SuccessDataResult<List<ProductDetailDto>>(result);
        }

        //look!!!
        //private IResult CheckProductNameLimit(string productName)
        //{
        //    var result = _productDal.GetAllAsync(p => p.Name == productName).Count();
        //    if (result <= 2)
        //    {
        //        return new ErrorResult(Messages.CheckProductNameLimit);
        //    }

        //    return new SuccessResult();
        //}
    }

}
