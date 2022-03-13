using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Abstract.OrderService;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract.OrderDal;
using Entities.Concrete;


namespace Business.Concrete.OrderManager
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public IResult Add(Order order)
        {
            _orderDal.Add(order);
            return new SuccessResult(Messages.OrderAdded);
        }

        public IResult Delete(Order order)
        {
            _orderDal.Delete(order);
            return new SuccessResult(Messages.OrderDeleted);
        }

        public async Task<IDataResult<IEnumerable<Order>>> GetAllAsync()
        {
            return new SuccessDataResult<IEnumerable<Order>>(await _orderDal.GetAllAsync(), Messages.OrderListed);
        }

        public async Task<IDataResult<Order>> GetByIdAsync(Guid orderId)
        {
            return new SuccessDataResult<Order>(await _orderDal.GetAsync(o => o.Id == orderId));
        }
        public IResult Update(Order order)
        {
            _orderDal.Update(order);
            return new SuccessResult(Messages.OrderUpdated);
        }
    }
}
