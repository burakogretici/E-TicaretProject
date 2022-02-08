using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract.UserService
{
    public interface IUserOperationClaimService 
    {
        IResult Add(UserOperationClaim brand);
        IResult Update(UserOperationClaim brand);
        IResult Delete(UserOperationClaim brand);

        IDataResult<List<UserOperationClaim>> GetAll();
        //IDataResult<UserOperationClaim> GetById(int id);
        //IDataResult<UserOperationClaim> GetByOperationClaim(int operationClaimId);
    }
}
