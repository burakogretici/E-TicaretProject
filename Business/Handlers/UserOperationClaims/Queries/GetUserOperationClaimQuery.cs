using System;
using System.Threading;
using System.Threading.Tasks;
using Business.Services.UserOperationClaims;
using Core.Utilities.Results;
using Entities.Dtos.UserOperationClaim;
using MediatR;

namespace Business.Handlers.UserOperationClaims.Queries
{
    public class GetUserOperationClaimQuery : IRequest<IDataResult<UserOperationClaimDto>>
    {
        public Guid Id { get; set; }

        public class GetUserOperationClaimQueryHandler : IRequestHandler<GetUserOperationClaimQuery, IDataResult<UserOperationClaimDto>>
        {
            private readonly IUserOperationClaimService _userOperationClaimService;

            public GetUserOperationClaimQueryHandler(IUserOperationClaimService userOperationClaimService)
            {
                _userOperationClaimService = userOperationClaimService;
            }
            public async Task<IDataResult<UserOperationClaimDto>> Handle(GetUserOperationClaimQuery request, CancellationToken cancellationToken)
            {
                var userOperationClaim = await _userOperationClaimService.GetByIdAsync(request.Id);
                return userOperationClaim;
            }
        }
    }
}
