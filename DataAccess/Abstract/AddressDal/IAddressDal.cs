using System.Collections.Generic;
using Core.DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract.AddressDal
{
    public interface IAddressDal : IEntityRepository<Address>
    {
        List<AddressDetailDto> GetAddressDetails();
    }
}
