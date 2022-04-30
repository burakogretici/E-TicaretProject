using System.Collections.Generic;
using System.Threading.Tasks;
using Core.DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Addresses;

namespace DataAccess.Abstract
{
    public interface IAddressRepository :  IEntityAsyncRepository<Address>
    {
        Task<List<AddressDetailDto>> GetAddressDetails();
    }
}
