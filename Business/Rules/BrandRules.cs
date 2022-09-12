using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
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

        public async Task<IResult> BrandNameAlreadyExists(string brandName)
        {
            var result = await _brandDal.AnyAsync(b => b.Name == brandName);
            if (!result) 
                return new SuccessResult();
            else
                return new ErrorResult(Messages.BrandNameAlreadyExists);


        }
    }
}