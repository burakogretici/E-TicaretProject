using System;
using System.Threading;
using System.Threading.Tasks;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using Entities.Enums;
using MediatR;

namespace Business.Handlers.Orders.Commands
{
    public class UpdateOrderCommand : IRequest<IResult>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid AddressId { get; set; }
        public Guid ShipperId { get; set; }
        public int Amount { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, IResult>
        {
            private readonly IUnitOfWork _unitOfWork;         

            public UpdateOrderCommandHandler(IUnitOfWork unitOfWork)
            {               
                _unitOfWork = unitOfWork;
            }

            public async Task<IResult> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
            {
                Order order = await _unitOfWork.OrderRepository.GetAsync(x => x.Id == request.Id);
                await _unitOfWork.OrderRepository.UpdateAsync(order);
                await _unitOfWork.Commit();
                return new SuccessResult(Messages.OrderUpdated);
            }
        }
    }
}