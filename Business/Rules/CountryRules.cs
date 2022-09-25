using Business.Constants;
using Core.Utilities.Results;
using System.Threading.Tasks;
using DataAccess.Abstract;

namespace Business.Rules
{
    public class CountryRules
    {
        private readonly ICountryRepository _countyRepository;

        public CountryRules(ICountryRepository countyRepository)
        {
            _countyRepository = countyRepository;
        }

        public async Task<IResult> CountryNameAlreadyExists(string countryDtoName)
        {
            var result = await _countyRepository.AnyAsync(b => b.Name == countryDtoName);
            if (!result)
                return new SuccessResult();
            else
                return new ErrorResult(Messages.CountryNameAlreadyExists);
        }
    }
}