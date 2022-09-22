using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Dtos.Addresses;

namespace Business.Services.Addresses
{
    public interface IAddressService
    {
        Task<IDataResult<AddressDto>> AddAsync(AddressDto address);
        Task<IResult> UpdateAsync(AddressDto address);
        Task<IResult> DeleteAsync(AddressDto address);

        Task<IDataResult<IEnumerable<AddressListDto>>> GetAllAsync();
        Task<IDataResult<AddressDto>> GetByIdAsync(Guid id);

        Task<IDataResult<IEnumerable<AddressListDto>>> GetAllByCountryIdAsync(Guid countryId);
        Task<IDataResult<IEnumerable<AddressListDto>>> GetAllByCityIdAsync(Guid cityId);
        Task<IDataResult<IEnumerable<AddressListDto>>> GetAllByUserIdAsync(Guid userId);
        Task<IDataResult<List<AddressDetailDto>>> GetAddressDetail();
    }
}