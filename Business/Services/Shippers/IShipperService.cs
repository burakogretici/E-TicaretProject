using Core.Utilities.Results;
using Entities.Dtos.Shippers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services.Shippers
{
    public interface IShipperService
    {
        Task<IDataResult<ShipperDto>> AddAsync(ShipperDto shipperDto);
        Task<IResult> UpdateAsync(ShipperDto shipperDto);
        Task<IResult> DeleteAsync(ShipperDto ShipperDto);

        Task<IDataResult<IEnumerable<ShipperDto>>> GetAllAsync();
        Task<IDataResult<ShipperDto>> GetByIdAsync(Guid id);
    }
}
