using System;
using Core.Utilities.Results;
using Entities.Dtos.OperationClaims;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services.OperationClaims
{
    public interface IOperationClaimService
    {
        Task<IDataResult<OperationClaimDto>> AddAsync(OperationClaimDto operationClaimDto);
        Task<IResult> UpdateAsync(OperationClaimDto operationClaimDto);
        Task<IResult> DeleteAsync(OperationClaimDto operationClaimDto);

        Task<IDataResult<IEnumerable<OperationClaimDto>>> GetAllAsync();
        Task<IDataResult<OperationClaimDto>> GetByIdAsync(Guid id);


    }
}
