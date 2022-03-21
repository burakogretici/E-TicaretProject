using System.Threading.Tasks;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;

namespace Business.Rules
{
    public class BrandRules
    {
        private readonly IBrandDal _brandDal;

        public BrandRules(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult BrandNameAlreadyExists(string brandName)
        {
            var result =  _brandDal.AnyAsync(b => b.Name == brandName).Result;
            if (result)
            {
                return new ErrorResult(Messages.BrandNameAlreadyExists);
            }

            return new SuccessResult();
        }

    }
}