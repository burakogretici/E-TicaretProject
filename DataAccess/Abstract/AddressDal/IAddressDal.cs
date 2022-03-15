using System.Collections.Generic;
using Core.DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.Addresses;

namespace DataAccess.Abstract.AddressDal
{
    public interface IAddressDal : IEntityRepository<Address>, IEntityAsyncRepository<Address>
    {
        List<AddressDetailDto> GetAddressDetails();
    }
}
