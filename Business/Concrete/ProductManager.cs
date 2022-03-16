using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Entities.DTOs.Products;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        private readonly IMapper _mapper;

        public ProductManager(IProductDal productDal, IMapper mapper)
        {
            _productDal = productDal;
            _mapper = mapper;
        }

        [ValidationAspect(typeof(ProductValidator))]
        //[SecuredOperation("Product.List")]
        public async Task<IDataResult<ProductDto>> AddAsync(ProductDto product)
        {
            //IResult result= BusinessRules.Run(CheckProductNameLimit(product.ProductName));
            //if (result != null)
            //{
            //    return (IDataResult<ProductDto>)result;
            //}

            var mapper = _mapper.Map<Product>(product);
            await _productDal.AddAsync(mapper);
            return new SuccessDataResult<ProductDto>(product, Messages.ProductAdded);
        }

        public async Task<IResult> UpdateAsync(Product product)
        {
            await _productDal.UpdateAsync(product);
            return new SuccessResult(Messages.ProductUpdated);
        }

        public async Task<IResult> DeleteAsync(Product product)
        {
            await _productDal.DeleteAsync(product);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public async Task<IDataResult<IEnumerable<ProductDto>>> GetAllAsync()
        {
            var result = await _productDal.GetAllAsync();
            var mapper = _mapper.Map<List<ProductDto>>(result);
            return new SuccessDataResult<IEnumerable<ProductDto>>(mapper, Messages.ProductListed);
        }

        public async Task<IDataResult<IEnumerable<ProductDto>>> GetAllByCategoryIdAsync(Guid categoryId)
        {
            var result = await _productDal.GetAllAsync(p => p.CategoryId == categoryId);
            var mapper = _mapper.Map<List<ProductDto>>(result);
            return new SuccessDataResult<IEnumerable<ProductDto>>(mapper);
        }

        public async Task<IDataResult<IEnumerable<ProductDto>>> GetByUnitPriceAsync(decimal min, decimal max)
        {
            var result = await _productDal.GetAllAsync(p => p.UnitPrice >= min && p.UnitPrice <= max);
            var mapper = _mapper.Map<List<ProductDto>>(result);
            return new SuccessDataResult<IEnumerable<ProductDto>>(mapper);
        }

        public async Task<IDataResult<ProductDto>> GetByIdAsync(Guid productId)
        {
            var result = await  _productDal.GetAsync(p => p.Id == productId);
            var mapper = _mapper.Map<ProductDto>(result);
            return new SuccessDataResult<ProductDto>(mapper);
        }

        public async Task<IDataResult<List<ProductDetailDto>>> GetProductDetails()
        {
            var result = await _productDal.GetProductDetails();
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
