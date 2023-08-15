using AutoMapper;
using Business.Constants;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services.Orders
{
    public class OrderManager : ServiceBase, IOrderService
    {
  
        public OrderManager(IServiceProvider serviceProvider) : base(serviceProvider)
        {       
        }

        public async Task<IResult> AddAsync(Order order)
        {
            await _unitOfWork.OrderRepository.AddAsync(order);
            return new SuccessResult(Messages.OrderAdded);
        }

        public async Task<IResult> DeleteAsync(Order order)
        {
            await _unitOfWork.OrderRepository.DeleteAsync(order);
            return new SuccessResult(Messages.OrderDeleted);
        }

        public async Task<IDataResult<IEnumerable<Order>>> GetAllAsync()
        {
            return new SuccessDataResult<IEnumerable<Order>>(await _unitOfWork.OrderRepository.GetAllAsync<Order>(null), Messages.OrderListed);
        }

        public async Task<IDataResult<Order>> GetByIdAsync(Guid orderId)
        {
            return new SuccessDataResult<Order>(await _unitOfWork.OrderRepository.GetAsync(o => o.Id == orderId));
        }
        public async Task<IResult> UpdateAsync(Order order)
        {
            await _unitOfWork.OrderRepository.UpdateAsync(order);
            return new SuccessResult(Messages.OrderUpdated);
        }
    }
}
