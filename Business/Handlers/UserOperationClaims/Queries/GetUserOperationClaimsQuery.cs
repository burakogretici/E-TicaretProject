using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Core.Utilities.Results;
using DataAccess.UnitOfWork;
using Entities.Dtos.Users;
using MediatR;

namespace Business.Handlers.UserOperationClaims.Queries
{
    public class GetUserOperationClaimsQuery : IRequest<IDataResult<IEnumerable<UserOperationClaimDto>>>
    {
        public class
            GetUserOperationClaimsQueryHandler : IRequestHandler<GetUserOperationClaimsQuery,
                IDataResult<IEnumerable<UserOperationClaimDto>>>
        {
            private readonly IUnitOfWork _unitOfWork;

            public GetUserOperationClaimsQueryHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<IDataResult<IEnumerable<UserOperationClaimDto>>> Handle(GetUserOperationClaimsQuery request, CancellationToken cancellationToken)
            {
                var userOperationClaimList = await _unitOfWork.UserOperationClaimRepository.GetAllAsync(
                    selector: x => new UserOperationClaimDto
                    {
                        UserFullName = x.User.FirstName + " " + x.User.LastName,
                        OperationClaim = x.OperationClaim.Name
                    }
                );
                return new SuccessDataResult<IEnumerable<UserOperationClaimDto>>(userOperationClaimList);
            }
        }
    }
}
