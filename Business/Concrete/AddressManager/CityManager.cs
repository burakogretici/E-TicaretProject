using System.Collections.Generic;
using AutoMapper;
using Business.Abstract.AddressService;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract.AddressDal;
using Entities.Concrete;
using Entities.DTOs;


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

        public IDataResult<CityDto> Add(CityDto city)
        {
            var mapper = _mapper.Map<City>(city);
            _cityDal.Add(mapper);
            return new SuccessDataResult<CityDto>(city, Messages.CityAdded);
        }

        public IResult Update(City city)
        {
            _cityDal.Update(city);
            return new SuccessResult(Messages.CityUpdated);
        }

        public IResult Delete(City city)
        {
            _cityDal.Delete(city);
            return new SuccessResult(Messages.CityDeleted);
        }

        public IDataResult<IEnumerable<CityDto>> GetAll()
        {
            var result = _cityDal.GetAll();
            var mapper = _mapper.Map<List<CityDto>>(result);
            return new SuccessDataResult<IEnumerable<CityDto>>(mapper,Messages.CityListed);
        }

        public IDataResult<IEnumerable<CityDto>> GetAllByCountry(int countryId)
        {
            var result = _cityDal.GetAll(city => city.CountryId == countryId);
            var mapper = _mapper.Map<List<CityDto>>(result);
            return new SuccessDataResult<IEnumerable<CityDto>>(mapper);
        }

        public IDataResult<CityDto> GetById(int cityId)
        {
            var result = _cityDal.Get(city => city.Id == cityId);
            var mapper = _mapper.Map<CityDto>(result);
            return new SuccessDataResult<CityDto>(mapper);
        }
    }
}
