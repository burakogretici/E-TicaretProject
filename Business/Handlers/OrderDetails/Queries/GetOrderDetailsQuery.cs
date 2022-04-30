using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Dtos.Orders;
using MediatR;

namespace Business.Handlers.OrderDetails.Queries
{
    public class GetOrderDetailsQuery : IRequest<IDataResult<IEnumerable<OrderDetailDto>>>
    {
        public class GetOrderDetailsQueryHandler : IRequestHandler<GetOrderDetailsQuery,
                IDataResult<IEnumerable<OrderDetailDto>>>
        {
            private readonly IUnitOfWork _unitOfWork;

            public GetOrderDetailsQueryHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<IDataResult<IEnumerable<OrderDetailDto>>> Handle(GetOrderDetailsQuery request,
                CancellationToken cancellationToken)
            {
                var customerList = await _unitOfWork.OrderDetailRepository.GetAllAsync(
                    selector: x => new OrderDetailDto
                    {


                    }
                );
                return new SuccessDataResult<IEnumerable<OrderDetailDto>>(customerList);
            }
        }
    }
}
