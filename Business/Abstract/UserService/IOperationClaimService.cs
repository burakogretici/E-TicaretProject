using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract.UserService
{
    public interface IOperationClaimService 
    {
        IResult Add(OperationClaim brand);
        IResult Update(OperationClaim brand);
        IResult Delete(OperationClaim brand);

        Task<IDataResult<IEnumerable<OperationClaim>>> GetAllAsync();
        //IDataResult<OperationClaim> GetById(int id);

        
    }
}
