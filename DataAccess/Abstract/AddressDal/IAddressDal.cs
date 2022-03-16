using System.Collections.Generic;
using System.Threading.Tasks;
using Core.DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.Addresses;

namespace DataAccess.Abstract.AddressDal
{
    public interface IAddressDal : IEntityRepository<Address>, IEntityAsyncRepository<Address>
    {
        Task<List<AddressDetailDto>> GetAddressDetails();
    }
}
