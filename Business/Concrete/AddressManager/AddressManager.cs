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
using Entities.DTOs.Addresses;

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

        public async Task<IDataResult<AddressDto>> AddAsync(AddressDto address)
        {
            var mapper = _mapper.Map<Address>(address);
            await _addressDal.AddAsync(mapper);
            return new SuccessDataResult<AddressDto>(address, Messages.AddressAdded);
        }

        public async Task<IResult> UpdateAsync(Address address)
        {
            await _addressDal.UpdateAsync(address);
            return new SuccessResult(Messages.AddressUpdated);
        }

        public async Task<IResult> DeleteAsync(Address address)
        {
            await _addressDal.DeleteAsync(address);
            return new SuccessResult(Messages.AddressDeleted);
        }

        public async Task<IDataResult<IEnumerable<AddressDto>>> GetAllAsync()
        {
            var result = await _addressDal.GetAllAsync();
            var mapper = _mapper.Map<IEnumerable<AddressDto>>(result);
            return new SuccessDataResult<IEnumerable<AddressDto>>(mapper, Messages.AddressListed);
        }

        public async Task<IDataResult<IEnumerable<AddressDto>>> GetAllByCountryIdAsync(Guid countryId)
        {
            var result = await _addressDal.GetAllAsync(address => address.CountryId == countryId);
            var mapper = _mapper.Map<IEnumerable<AddressDto>>(result);
            return new SuccessDataResult<IEnumerable<AddressDto>>(mapper, Messages.AddressListed);
        }

        public async Task<IDataResult<IEnumerable<AddressDto>>> GetAllByCityIdAsync(Guid cityId)
        {
            var result = await _addressDal.GetAllAsync(address => address.CityId == cityId);
            var mapper = _mapper.Map<IEnumerable<AddressDto>>(result);
            return new SuccessDataResult<IEnumerable<AddressDto>>(mapper);
        }

        public async Task<IDataResult<IEnumerable<AddressDto>>> GetAllByUserIdAsync(Guid userId)
        {
            var result = await _addressDal.GetAllAsync(address => address.UserId == userId);
            var mapper = _mapper.Map<IEnumerable<AddressDto>>(result);
            return new SuccessDataResult<IEnumerable<AddressDto>>(mapper);
        }
        public async Task<IDataResult<AddressDto>> GetByIdAsync(Guid addressId)
        {
            var result = await _addressDal.GetAsync(address => address.Id == addressId);
            var mapper = _mapper.Map<AddressDto>(result);
            return new SuccessDataResult<AddressDto>(mapper);
        }

        public IDataResult<List<AddressDetailDto>> GetAddressDetail()
        {
            return new SuccessDataResult<List<AddressDetailDto>>(_addressDal.GetAddressDetails());
        }
    }
}
