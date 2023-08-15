using Business.Constants;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Core.CrossCuttingConcerns.Exceptions;

namespace Business.Rules
{
    public class CountryRules
    {
        private readonly ICountryRepository _countyRepository;

        public CountryRules(ICountryRepository countyRepository)
        {
            _countyRepository = countyRepository;
        }

        public async Task CountryNameAlreadyExists(string countryDtoName)
        {
            var result = await _countyRepository.AnyAsync(b => b.Name == countryDtoName);
            if (result) throw new BusinessException(Messages.CountryNameAlreadyExists);
        }
    }
}