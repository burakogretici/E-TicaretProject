using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Business.Services.OperationClaims;
using Core.Utilities.Results;
using Entities.Dtos.OperationClaims;
using MediatR;

namespace Business.Handlers.OperationClaims.Queries
{
    public class GetOperationClaimsQuery : IRequest<IDataResult<IEnumerable<OperationClaimDto>>>
    {
        public class GetOperationClaimsQueryHandler : IRequestHandler<GetOperationClaimsQuery, IDataResult<IEnumerable<OperationClaimDto>>>
        {
            private readonly IOperationClaimService _operationClaimService;

            public GetOperationClaimsQueryHandler(IOperationClaimService operationClaimService)
            {
                _operationClaimService = operationClaimService;
            }

            public async Task<IDataResult<IEnumerable<OperationClaimDto>>> Handle(GetOperationClaimsQuery request, CancellationToken cancellationToken)
            {
                var operationClaimList = await _operationClaimService.GetAllAsync();
                return operationClaimList;
            }
        }
    }
}
