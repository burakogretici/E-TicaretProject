using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
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
        public Guid CustomerId { get; set; }
        public Guid AddressId { get; set; }
        public Guid ShipperId { get; set; }
        public int Amount { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, IResult>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public UpdateOrderCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
            {
                _mapper = mapper;
                _unitOfWork = unitOfWork;
            }

            public async Task<IResult> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
            {
                var mapper = _mapper.Map<Order>(request);
                await _unitOfWork.OrderRepository.UpdateAsync(mapper);
                await _unitOfWork.Commit();
                return new SuccessResult(Messages.OrderUpdated);
            }
        }
    }
}