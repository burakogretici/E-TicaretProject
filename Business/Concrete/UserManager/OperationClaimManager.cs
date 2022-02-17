using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Abstract.UserService;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract.UserDal;
using Entities.Concrete;

namespace Business.Concrete.UserManager
{
    public class OperationClaimManager : IOperationClaimService
    {
        private readonly IOperationClaimDal _operationClaimDal;

        public OperationClaimManager(IOperationClaimDal operationClaimDal)
        {
            _operationClaimDal = operationClaimDal;
        }

        public IResult Add(OperationClaim operationClaim)
        {
            _operationClaimDal.Add(operationClaim);
            return new SuccessResult(Messages.OperationClaimAdded);

        }

        public IResult Update(OperationClaim operationClaim)
        {
            _operationClaimDal.Update(operationClaim);
            return new SuccessResult(Messages.OperationClaimUpdated);
        }

        public IResult Delete(OperationClaim operationClaim)
        {
            _operationClaimDal.Delete(operationClaim);
            return new SuccessResult(Messages.OperationClaimDeleted);
        }

        public async Task<IDataResult<IEnumerable<OperationClaim>>> GetAllAsync()
        {
            return new SuccessDataResult<IEnumerable<OperationClaim>>(await _operationClaimDal.GetAllAsync(), Messages.OperationClaimListed);
        }

        //public IDataResult<OperationClaim> GetByOperationClaim(int operationClaimId)
        //{
        //    return  new SuccessDataResult<OperationClaim>(_operationClaimDal.Get(oc=>oc.Id == operationClaimId));
        //}
    }
}
