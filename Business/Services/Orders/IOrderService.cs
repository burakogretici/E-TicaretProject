using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services.Orders
{
    public interface IOrderService
    {
        Task<IResult> AddAsync(Order order);
        Task<IResult> UpdateAsync(Order order);
        Task<IResult> DeleteAsync(Order order);

        Task<IDataResult<IEnumerable<Order>>> GetAllAsync();
        Task<IDataResult<Order>> GetByIdAsync(Guid id);
    }
}
