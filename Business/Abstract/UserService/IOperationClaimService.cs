using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract.UserService
{
    public interface IOperationClaimService 
    {
        IResult Add(OperationClaim brand);
        IResult Update(OperationClaim brand);
        IResult Delete(OperationClaim brand);

        IDataResult<List<OperationClaim>> GetAll();
        //IDataResult<OperationClaim> GetById(int id);

        
    }
}
