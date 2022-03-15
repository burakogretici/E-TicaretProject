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

        public async Task<IResult> AddAsync(Order order)
        {
            await _orderDal.AddAsync(order);
            return new SuccessResult(Messages.OrderAdded);
        }

        public async Task<IResult> DeleteAsync(Order order)
        {
            await _orderDal.DeleteAsync(order);
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
        public async Task<IResult> UpdateAsync(Order order)
        {
            _orderDal.UpdateAsync(order);
            return new SuccessResult(Messages.OrderUpdated);
        }
    }
}
