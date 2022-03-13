using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract.UserService
{
    public interface IUserOperationClaimService 
    {
        IResult Add(UserOperationClaim brand);
        IResult Update(UserOperationClaim brand);
        IResult Delete(UserOperationClaim brand);

        Task<IDataResult<IEnumerable<UserOperationClaim>>> GetAllAsync();
        //IDataResult<UserOperationClaim> GetById(int id);
        //IDataResult<UserOperationClaim> GetByOperationClaim(int operationClaimId);
    }
}
