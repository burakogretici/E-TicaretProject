using System;
using Core.Utilities.Results;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Abstract.OrderService
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
