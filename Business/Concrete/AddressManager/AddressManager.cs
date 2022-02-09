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
    public class AddressManager : IAddressService
    {
        private readonly IAddressDal _addressDal;
        private readonly IMapper _mapper;

        public AddressManager(IAddressDal addressDal, IMapper mapper)
        {
            _addressDal = addressDal;
            _mapper = mapper;
        }

        public IDataResult<AddressDto> Add(AddressDto address)
        {
            var mapper = _mapper.Map<Address>(address);
            _addressDal.Add(mapper);
            return new SuccessDataResult<AddressDto>(address, Messages.AddressAdded);
        }

        public IResult Update(Address address)
        {
            _addressDal.Update(address);
            return new SuccessResult(Messages.AddressUpdated);
        }

        public IResult Delete(Address address)
        {
            _addressDal.Delete(address);
            return new SuccessResult(Messages.AddressDeleted);
        }

        public IDataResult<IEnumerable<AddressDto>> GetAll()
        {
            var result = _addressDal.GetAll();
            var mapper = _mapper.Map<IEnumerable<AddressDto>>(result);
            return new SuccessDataResult<IEnumerable<AddressDto>>(mapper, Messages.AddressListed);
        }

        public IDataResult<IEnumerable<AddressDto>> GetAllByCountryId(int countryId)
        {
            var result = _addressDal.GetAll(address => address.CountryId == countryId);
            var mapper = _mapper.Map<IEnumerable<AddressDto>>(result);
            return new SuccessDataResult<IEnumerable<AddressDto>>(mapper,Messages.AddressListed);
        }

        public IDataResult<IEnumerable<AddressDto>> GetAllByCityId(int cityId)
        {
            var result = _addressDal.GetAll(address => address.CityId == cityId);
            var mapper = _mapper.Map<IEnumerable<AddressDto>>(result);
            return new SuccessDataResult<IEnumerable<AddressDto>>(mapper);
        }

        public IDataResult<IEnumerable<AddressDto>> GetAllByUserId(int userId)
        {
            var result = _addressDal.GetAll(address => address.UserId == userId);
            var mapper = _mapper.Map<IEnumerable<AddressDto>>(result);
            return new SuccessDataResult<IEnumerable<AddressDto>>(mapper);
        }
        public IDataResult<AddressDto> GetById(int addressId)
        {
            var result = _addressDal.Get(address => address.Id == addressId);
            var mapper = _mapper.Map<AddressDto>(result);
            return new SuccessDataResult<AddressDto>(mapper);
        }

        public IDataResult<List<AddressDetailDto>> GetAddressDetail()
        {
            return new SuccessDataResult<List<AddressDetailDto>>(_addressDal.GetAddressDetails());
        }
    }
}
