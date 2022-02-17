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
        Task<IDataResult<AddressDto>> GetByIdAsync(int id);

        Task<IDataResult<IEnumerable<AddressDto>>> GetAllByCountryIdAsync(int countryId);
        Task<IDataResult<IEnumerable<AddressDto>>> GetAllByCityIdAsync(int cityId);
        Task<IDataResult<IEnumerable<AddressDto>>> GetAllByUserIdAsync(int userId);
        IDataResult<List<AddressDetailDto>> GetAddressDetail();
    }
}
