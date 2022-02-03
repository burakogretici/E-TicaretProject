using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;

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
