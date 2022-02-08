using System.Collections.Generic;
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

        public AddressManager(IAddressDal addressDal)
        {
            _addressDal = addressDal;
        }

        public IResult Add(Address address)
        {
            _addressDal.Add(address);
            return new SuccessResult(Messages.AddressAdded);
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

        public IDataResult<List<Address>> GetAll()
        {
            return new SuccessDataResult<List<Address>>(_addressDal.GetAll(),Messages.AddressListed);
        }

        public IDataResult<List<Address>> GetAllByCountryId(int countryId)
        {
            return new SuccessDataResult<List<Address>>(_addressDal.GetAll(address => address.CountryId == countryId));
        }

        public IDataResult<List<Address>> GetAllByCityId(int cityId)
        {
            return new SuccessDataResult<List<Address>>(_addressDal.GetAll(address => address.CityId == cityId));
        }

        public IDataResult<Address> GetById(int addressId)
        {
            return new SuccessDataResult<Address>(_addressDal.Get(address => address.Id == addressId));
        }

        public IDataResult<List<AddressDetailDto>> GetAddressDetail()
        {
            return new SuccessDataResult<List<AddressDetailDto>>(_addressDal.GetAddressDetails());
        }
    }
}
