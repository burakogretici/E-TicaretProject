using System.Threading.Tasks;
using Business.Constants;
using Core.CrossCuttingConcerns.Exceptions;
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

        public async Task CityNameAlreadyExists(string cityDtoName)
        {
            var result = await _cityRepository.AnyAsync(b => b.Name == cityDtoName);
            if (result) throw new BusinessException(Messages.CityNameAlreadyExists);
          
        }
    }
}