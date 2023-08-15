//using System;
//using System.Threading;
//using System.Threading.Tasks;
//using AutoMapper;
//using Core.Utilities.Results;
//using DataAccess.UnitOfWork;
//using Entities.Dtos.Orders;
//using MediatR;

//namespace Business.Handlers.Orders.Queries
//{
//    public class GetOrderQuery : IRequest<IDataResult<OrderDto>>
//    {
//        public Guid Id { get; set; }

//        public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, IDataResult<OrderDto>>
//        {
//            private readonly IUnitOfWork _unitOfWork;
//            private readonly IMapper _mapper;

//            public GetOrderQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
//            {
//                _unitOfWork = unitOfWork;
//                _mapper = mapper;
//            }

//            public async Task<IDataResult<OrderDto>> Handle(GetOrderQuery request, CancellationToken cancellationToken)
//            {
//                var order = await _unitOfWork.OrderRepository.GetAsync(a => a.Id == request.Id);
//                var orderDto = _mapper.Map<OrderDto>(order);
//                return new SuccessDataResult<OrderDto>(orderDto);
//            }
//        }
//    }
//}
