using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Dtos.Orders;
using MediatR;

namespace Business.Handlers.OrderDetails.Queries
{
    public class GetOrderDetailQuery : IRequest<IDataResult<OrderDetailDto>>
    {
        public Guid Id { get; set; }

        public class GetOrderDetailQueryHandler : IRequestHandler<GetOrderDetailQuery, IDataResult<OrderDetailDto>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public GetOrderDetailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<IDataResult<OrderDetailDto>> Handle(GetOrderDetailQuery request, CancellationToken cancellationToken)
            {
                //todo:bir daha incele
                var orderDetail = await _unitOfWork.OrderDetailRepository.GetAsync(a => a.OrderId == request.Id);
                var orderDetailDto = _mapper.Map<OrderDetailDto>(orderDetail);
                return new SuccessDataResult<OrderDetailDto>(orderDetailDto);
            }
        }
    }
}
