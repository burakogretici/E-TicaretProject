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
    public class CountryManager : ICountryService
    {
        private readonly ICountryDal _countryDal;
        private readonly IMapper _mapper;

        public CountryManager(ICountryDal countryDal, IMapper mapper)
        {
            _countryDal = countryDal;
            _mapper = mapper;
        }

        public IDataResult<CountryDto> Add(CountryDto country)
        {
            var mapper = _mapper.Map<Country>(country);
            _countryDal.Add(mapper);
            return new SuccessDataResult<CountryDto>(country,Messages.CountryAdded);
        }

        public IResult Update(Country country)
        {
            _countryDal.Update(country);
            return new SuccessResult(Messages.CountryUpdated);
        }

        public IResult Delete(Country country)
        {
            _countryDal.Delete(country);
            return new SuccessResult(Messages.CountryDeleted);
        }

        public IDataResult<IEnumerable<CountryDto>> GetAll()
        {
            var result = _countryDal.GetAll();
            var mapper = _mapper.Map<List<CountryDto>>(result);
            return new SuccessDataResult<IEnumerable<CountryDto>>(mapper,Messages.CountryListed);
        }
        public IDataResult<CountryDto> GetById(int countryId)
        {
            var result = _countryDal.Get(country => country.Id == countryId);
            var mapper = _mapper.Map<CountryDto>(result);
            return new SuccessDataResult<CountryDto>(mapper);
        }
    }
}
