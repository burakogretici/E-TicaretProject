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
using Entities.DTOs.Cities;


namespace Business.Concrete.AddressManager
{
    public class CityManager : ICityService
    {
        private readonly ICityDal _cityDal;
        private readonly IMapper _mapper;

        public CityManager(ICityDal cityDal, IMapper mapper)
        {
            _cityDal = cityDal;
            _mapper = mapper;
        }

        public async Task<IDataResult<CityDto>> AddAsync(CityDto city)
        {
            var mapper = _mapper.Map<City>(city);
            await _cityDal.AddAsync(mapper);
            return new SuccessDataResult<CityDto>(city, Messages.CityAdded);
        }

        public async Task<IResult> UpdateAsync(City city)
        {
            await _cityDal.UpdateAsync(city);
            return new SuccessResult(Messages.CityUpdated);
        }

        public async Task<IResult> DeleteAsync(City city)
        {
            await _cityDal.DeleteAsync(city);
            return new SuccessResult(Messages.CityDeleted);
        }

        public async Task<IDataResult<IEnumerable<CityDto>>> GetAllAsync()
        {
            var result = await _cityDal.GetAllAsync();
            var mapper = _mapper.Map<List<CityDto>>(result);
            return new SuccessDataResult<IEnumerable<CityDto>>(mapper, Messages.CityListed);
        }

        public async Task<IDataResult<IEnumerable<CityDto>>> GetAllByCountryAsync(Guid countryId)
        {
            var result = await _cityDal.GetAllAsync(city => city.CountryId == countryId);
            var mapper = _mapper.Map<List<CityDto>>(result);
            return new SuccessDataResult<IEnumerable<CityDto>>(mapper);
        }

        public async Task<IDataResult<CityDto>> GetByIdAsync(Guid cityId)
        {
            var result = await _cityDal.GetAsync(city => city.Id == cityId);
            var mapper = _mapper.Map<CityDto>(result);
            return new SuccessDataResult<CityDto>(mapper);
        }
    }
}
