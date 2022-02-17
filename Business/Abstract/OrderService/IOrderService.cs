using Core.Utilities.Results;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Abstract.OrderService
{
    public interface IOrderService 
    {
        IResult Add(Order order);
        IResult Update(Order order);
        IResult Delete(Order order);

        Task<IDataResult<IEnumerable<Order>>> GetAllAsync();
        Task<IDataResult<Order>> GetByIdAsync(long id);
    }
}
