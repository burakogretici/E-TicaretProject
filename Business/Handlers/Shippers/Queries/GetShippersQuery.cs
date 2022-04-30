using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Dtos.Shippers;
using MediatR;

namespace Business.Handlers.Shippers.Queries
{
    public class GetShippersQuery : IRequest<IDataResult<IEnumerable<ShipperDto>>>
    {
        public class GetShippersQueryHandler : IRequestHandler<GetShippersQuery, IDataResult<IEnumerable<ShipperDto>>>
        {
            private readonly IUnitOfWork _unitOfWork;

            public GetShippersQueryHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<IDataResult<IEnumerable<ShipperDto>>> Handle(GetShippersQuery request,
                CancellationToken cancellationToken)
            {
                var shipperList = await _unitOfWork.UserOperationClaimRepository.GetAllAsync(
                    selector: x => new ShipperDto
                    {
                       

                    }
                );
                return new SuccessDataResult<IEnumerable<ShipperDto>>(shipperList);
            }
        }
    }
}
