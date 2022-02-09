using Core.Utilities.Results;
using System.Collections.Generic;
using Entities.Concrete;

namespace Business.Abstract.OrderService
{
    public interface IOrderService 
    {
        IResult Add(Order order);
        IResult Update(Order order);
        IResult Delete(Order order);

        IDataResult<IEnumerable<Order>> GetAll();
        IDataResult<Order> GetById(long id);
    }
}
