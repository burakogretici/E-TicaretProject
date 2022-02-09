using System.Collections.Generic;
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

        public IDataResult<IEnumerable<Order>> GetAll()
        {
            return new SuccessDataResult<IEnumerable<Order>>(_orderDal.GetAll(),Messages.OrderListed);
        }

        public IDataResult<Order> GetById(long orderId)
        {
            return new SuccessDataResult<Order>(_orderDal.Get(o=> o.Id == orderId));
        }
        public IResult Update(Order order)
        {
            _orderDal.Update(order);
            return new SuccessResult(Messages.OrderUpdated);
        }
    }
}
