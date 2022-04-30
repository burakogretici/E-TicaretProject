using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using MediatR;

namespace Business.Handlers.OrderDetails.Commands
{
    public class CreateOrderDetailCommand : IRequest<IResult>
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Amount { get; set; }
        public int SalePrice { get; set; }

        public class CreateOrderDetailCommandHandler : IRequestHandler<CreateOrderDetailCommand, IResult>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public CreateOrderDetailCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
            {
                _mapper = mapper;
                _unitOfWork = unitOfWork;
            }

            public async Task<IResult> Handle(CreateOrderDetailCommand request, CancellationToken cancellationToken)
            {
                var mapper = _mapper.Map<OrderDetail>(request);
                await _unitOfWork.OrderDetailRepository.AddAsync(mapper);
                await _unitOfWork.Commit();
                return new SuccessResult(Messages.CountryAdded);
            }
        }
    }
}