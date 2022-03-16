using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Entities.DTOs.Addresses;

namespace Business.Abstract.AddressService
{
    public interface IAddressService
    {
        Task<IDataResult<AddressDto>> AddAsync(AddressDto address);
        Task<IResult> UpdateAsync(Address address);
        Task<IResult> DeleteAsync(Address address);

        Task<IDataResult<IEnumerable<AddressDto>>> GetAllAsync();
        Task<IDataResult<AddressDto>> GetByIdAsync(Guid id);

        Task<IDataResult<IEnumerable<AddressDto>>> GetAllByCountryIdAsync(Guid countryId);
        Task<IDataResult<IEnumerable<AddressDto>>> GetAllByCityIdAsync(Guid cityId);
        Task<IDataResult<IEnumerable<AddressDto>>> GetAllByUserIdAsync(Guid userId);
        Task<IDataResult<List<AddressDetailDto>>> GetAddressDetail();
    }
}
