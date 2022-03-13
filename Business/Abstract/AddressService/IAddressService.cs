using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        Task<IDataResult<IEnumerable<AddressDto>>> GetAllAsync();
        Task<IDataResult<AddressDto>> GetByIdAsync(Guid id);

        Task<IDataResult<IEnumerable<AddressDto>>> GetAllByCountryIdAsync(Guid countryId);
        Task<IDataResult<IEnumerable<AddressDto>>> GetAllByCityIdAsync(Guid cityId);
        Task<IDataResult<IEnumerable<AddressDto>>> GetAllByUserIdAsync(Guid userId);
        IDataResult<List<AddressDetailDto>> GetAddressDetail();
    }
}
