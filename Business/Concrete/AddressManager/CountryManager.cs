using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract.AddressService;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract.AddressDal;
using Entities.Concrete;
using Entities.DTOs;
using Entities.DTOs.Countries;


namespace Business.Concrete.AddressManager
{
    public class CountryManager : ICountryService
    {
        private readonly ICountryDal _countryDal;
        private readonly IMapper _mapper;

        public CountryManager(ICountryDal countryDal, IMapper mapper)
        {
            _countryDal = countryDal;
            _mapper = mapper;
        }

        public async Task<IDataResult<CountryDto>> AddAsync(CountryDto country)
        {
            var mapper = _mapper.Map<Country>(country);
            await _countryDal.AddAsync(mapper);
            return new SuccessDataResult<CountryDto>(country, Messages.CountryAdded);
        }

        public async Task<IResult> UpdateAsync(Country country)
        {
            await _countryDal.UpdateAsync(country);
            return new SuccessResult(Messages.CountryUpdated);
        }

        public async Task<IResult> DeleteAsync(Country country)
        {
            await _countryDal.DeleteAsync(country);
            return new SuccessResult(Messages.CountryDeleted);
        }

        public async Task<IDataResult<IEnumerable<CountryDto>>> GetAllAsync()
        {
            var result = await _countryDal.GetAllAsync();
            var mapper = _mapper.Map<List<CountryDto>>(result);
            return new SuccessDataResult<IEnumerable<CountryDto>>(mapper, Messages.CountryListed);
        }
        public async Task<IDataResult<CountryDto>> GetByIdAsync(Guid countryId)
        {
            var result = await _countryDal.GetAsync(country => country.Id == countryId);
            var mapper = _mapper.Map<CountryDto>(result);
            return new SuccessDataResult<CountryDto>(mapper);
        }
    }
}
