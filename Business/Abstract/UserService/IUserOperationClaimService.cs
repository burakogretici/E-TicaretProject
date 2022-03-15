using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract.UserService
{
    public interface IUserOperationClaimService 
    {
        Task<IResult> AddAsync(UserOperationClaim brand);
        Task<IResult> UpdateAsync(UserOperationClaim brand);
        Task<IResult> DeleteAsync(UserOperationClaim brand);

        Task<IDataResult<IEnumerable<UserOperationClaim>>> GetAllAsync();
        //IDataResult<UserOperationClaim> GetById(int id);
        //IDataResult<UserOperationClaim> GetByOperationClaim(int operationClaimId);
    }
}
