using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract.UserService
{
    public interface IOperationClaimService 
    {
        Task<IResult> AddAsync(OperationClaim brand);
        Task<IResult> UpdateAsync(OperationClaim brand);
        Task<IResult> DeleteAsync(OperationClaim brand);

        Task<IDataResult<IEnumerable<OperationClaim>>> GetAllAsync();
        //IDataResult<OperationClaim> GetById(int id);

        
    }
}
