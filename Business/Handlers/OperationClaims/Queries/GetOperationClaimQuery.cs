using System;
using System.Threading;
using System.Threading.Tasks;
using Business.Services.OperationClaims;
using Core.Utilities.Results;
using Entities.Dtos.OperationClaims;
using MediatR;

namespace Business.Handlers.OperationClaims.Queries
{
    public class GetOperationClaimQuery : IRequest<IDataResult<OperationClaimDto>>
    {
        public Guid Id { get; set; }

        public class GetOperationClaimQueryHandler : IRequestHandler<GetOperationClaimQuery, IDataResult<OperationClaimDto>>
        {
            private readonly IOperationClaimService _operationClaimService;

            public GetOperationClaimQueryHandler(IOperationClaimService operationClaimService)
            {
                _operationClaimService = operationClaimService;
            }
            public async Task<IDataResult<OperationClaimDto>> Handle(GetOperationClaimQuery request, CancellationToken cancellationToken)
            {
                var operationClaim = await _operationClaimService.GetByIdAsync(request.Id);
                return operationClaim;
            }
        }
    }
}
