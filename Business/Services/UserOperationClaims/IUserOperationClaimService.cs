using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Dtos.UserOperationClaim;

namespace Business.Services.UserOperationClaims
{

    public interface IUserOperationClaimService
    {
        Task<IResult> AddAsync(UserOperationClaimDto userOperationClaimDto);
        Task<IResult> UpdateAsync(UserOperationClaimDto userOperationClaimDto);
        Task<IResult> DeleteAsync(UserOperationClaimDto userOperationClaimDto);

        Task<IDataResult<IEnumerable<UserOperationClaimDto>>> GetAllAsync();
        Task<IDataResult<UserOperationClaimDto>> GetByIdAsync(Guid id);


        Task<IDataResult<IEnumerable<UserOperationClaimDto>>> GetAllByOperationClaim(Guid operationClaimId);
        Task<IDataResult<IEnumerable<UserOperationClaimDto>>> GetAllByUser(Guid userId);



    }
}
