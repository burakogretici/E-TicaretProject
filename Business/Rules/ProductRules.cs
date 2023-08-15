using System.Threading.Tasks;
using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Abstract;

namespace Business.Rules
{
    public class ProductRules
    {
        private readonly IProductRepository _productDal;

        public ProductRules(IProductRepository productDal)
        {
            _productDal = productDal;
        }

        public async Task ProductAlreadyExists(string code)
        {
            var result = await _productDal.AnyAsync(p => p.Code == code);
            if (result) throw new BusinessException($" {code} Ürün Kodu başka bir üründe kullanılmaktadır.");
        }
    }
}