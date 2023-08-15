//using System.Collections.Generic;
//using System.Threading;
//using System.Threading.Tasks;
//using Core.Utilities.Results;
//using DataAccess.UnitOfWork;
//using Entities.Dtos.Orders;
//using MediatR;

//namespace Business.Handlers.Orders.Queries
//{
//    public class GetOrdersQuery : IRequest<IDataResult<IEnumerable<OrderDto>>>
//    {
//        public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, IDataResult<IEnumerable<OrderDto>>>
//        {
//            private readonly IUnitOfWork _unitOfWork;

//            public GetOrdersQueryHandler(IUnitOfWork unitOfWork)
//            {
//                _unitOfWork = unitOfWork;
//            }

//            public async Task<IDataResult<IEnumerable<OrderDto>>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
//            {
//                var orderList = await _unitOfWork.OrderRepository.GetAllAsync(
//                    selector: x => new OrderDto
//                    {
//                        Id = x.Id,
//                        CustomerFullName = x.Customer.User.FirstName + " " + x.Customer.User.LastName,
//                        Address = x.Address.City.Name + " / " + x.Address.Country,
//                        Shipper = x.Shipper.Name,
//                        Amount = x.Amount,
//                        OrderStatus = x.OrderStatus
//                    }
//                );
//                return new SuccessDataResult<IEnumerable<OrderDto>>(orderList);
//            }
//        }
//    }
//}
