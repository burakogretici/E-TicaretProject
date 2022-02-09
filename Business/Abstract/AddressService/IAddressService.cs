using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract.AddressService
{
    public interface IAddressService
    {
        IDataResult<AddressDto> Add(AddressDto address);
        IResult Update(Address address);
        IResult Delete(Address address);

        IDataResult<IEnumerable<AddressDto>> GetAll();
        IDataResult<AddressDto> GetById(int id);

        IDataResult<IEnumerable<AddressDto>> GetAllByCountryId(int countryId);
        IDataResult<IEnumerable<AddressDto>> GetAllByCityId(int cityId);
        IDataResult<IEnumerable<AddressDto>> GetAllByUserId(int userId);
        IDataResult<List<AddressDetailDto>> GetAddressDetail();
    }
}
