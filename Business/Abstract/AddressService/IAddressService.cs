using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract.AddressService
{
    public interface IAddressService
    {
        IResult Add(Address address);
        IResult Update(Address address);
        IResult Delete(Address address);

        IDataResult<List<Address>> GetAll();
        IDataResult<List<Address>> GetAllByCountryId(int countryId);
        IDataResult<List<Address>> GetAllByCityId(int cityId);
        IDataResult<Address> GetById(int addressId);

        IDataResult<List<AddressDetailDto>> GetAddressDetail();
    }
}
