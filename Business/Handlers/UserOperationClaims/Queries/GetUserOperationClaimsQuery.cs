using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Business.Services.UserOperationClaims;
using Core.Utilities.Results;
using Entities.Dtos.UserOperationClaim;
using MediatR;

namespace Business.Handlers.UserOperationClaims.Queries
{
    public class GetUserOperationClaimsQuery : IRequest<IDataResult<IEnumerable<UserOperationClaimDto>>>
    {
        public class GetUserOperationClaimsQueryHandler : IRequestHandler<GetUserOperationClaimsQuery, IDataResult<IEnumerable<UserOperationClaimDto>>>
        {
            private readonly IUserOperationClaimService _userOperationClaimService;

            public GetUserOperationClaimsQueryHandler(IUserOperationClaimService userOperationClaimService)
            {
                _userOperationClaimService = userOperationClaimService;
            }

            public async Task<IDataResult<IEnumerable<UserOperationClaimDto>>> Handle(GetUserOperationClaimsQuery request, CancellationToken cancellationToken)
            {
                var userOperationClaimList = await _userOperationClaimService.GetAllAsync();
                return userOperationClaimList;
            }
        }
    }
}
