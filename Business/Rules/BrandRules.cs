using Business.Constants;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System.Threading.Tasks;

namespace Business.Rules
{
    public class BrandRules
    {
        private readonly IBrandRepository _brandDal;

        public BrandRules(IBrandRepository brandDal)
        {
            _brandDal = brandDal;
        }

       
        public async Task BrandNameAlreadyExists(string brandName)
        {
            var result = await _brandDal.AnyAsync(b => b.Name == brandName);
            if (result) throw new BusinessException(Messages.BrandNameAlreadyExists);
        }

    }
}