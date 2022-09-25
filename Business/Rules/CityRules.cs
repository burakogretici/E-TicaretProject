using System.Threading.Tasks;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;

namespace Business.Rules
{
    public class CityRules
    {
        private readonly ICityRepository _cityRepository;

        public CityRules(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<IResult> CityNameAlreadyExists(string cityDtoName)
        {
            var result = await _cityRepository.AnyAsync(b => b.Name == cityDtoName);
            if (!result)
                return new SuccessResult();
            else
                return new ErrorResult(Messages.CityNameAlreadyExists);
        }
    }
}