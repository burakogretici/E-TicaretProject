using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Dtos.OperationClaims;
using MediatR;

namespace Business.Handlers.OperationClaims.Queries
{
    public class GetOperationClaimsQuery : IRequest<IDataResult<IEnumerable<OperationClaimDto>>>
    {
        public class GetOperationClaimsQueryHandler : IRequestHandler<GetOperationClaimsQuery, IDataResult<IEnumerable<OperationClaimDto>>>
        {
            private readonly IUnitOfWork _unitOfWork;

            public GetOperationClaimsQueryHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<IDataResult<IEnumerable<OperationClaimDto>>> Handle(GetOperationClaimsQuery request, CancellationToken cancellationToken)
            {
                var customerList = await _unitOfWork.OperationClaimRepository.GetAllAsync(
                    selector: x => new OperationClaimDto
                    {
                        Id = x.Id,
                        Name = x.Name
                    }
                );
                return new SuccessDataResult<IEnumerable<OperationClaimDto>>(customerList);
            }
        }
    }
}
