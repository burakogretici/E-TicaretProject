using System;
using System.Threading.Tasks;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Rules
{
    public class ProductRules
    {
        private readonly IProductRepository _productDal;

        public ProductRules(IProductRepository productDal)
        {
            _productDal = productDal;
        }

        public async Task<IResult> ProductAlreadyExists(string code)
        {
            var result = await _productDal.AnyAsync(p => p.Code == code);
            if (result)
            {
                return new ErrorResult($" {code} Ürün Kodu başka bir üründe kullanılmaktadır.");
            }
            
            return new SuccessResult();
        }
    }
}