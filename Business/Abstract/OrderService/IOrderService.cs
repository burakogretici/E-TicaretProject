using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Core.Business.Abstract;

namespace Business.Abstract.OrderService
{
    public interface IOrderService 
    {
        IResult Add(Order order);
        IResult Update(Order order);
        IResult Delete(Order order);

        IDataResult<List<Order>> GetAll();
        IDataResult<Order> GetById(long id);
    }
}
