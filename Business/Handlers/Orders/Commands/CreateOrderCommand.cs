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
    public class CreateOrderCommand : IRequest<IResult>
    {
        public Guid UserId { get; set; }
        public Guid AddressId { get; set; }
        public Guid ShipperId { get; set; }
        public Guid BasketId { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, IResult>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public CreateOrderCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
            {
                _mapper = mapper;
                _unitOfWork = unitOfWork;
            }

            public async Task<IResult> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
            {
                    var mapper = _mapper.Map<Order>(request);
                    await _unitOfWork.OrderRepository.AddAsync(mapper);
                    await _unitOfWork.Commit();
                    return new SuccessResult(Messages.OrderAdded);             
            }
        }
    }
}
