using System.Collections.Generic;
using Business.Abstract.UserService;
using Business.Constants;
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

        public IDataResult<List<OperationClaim>> GetAll()
        {
            return new SuccessDataResult<List<OperationClaim>>(_operationClaimDal.GetAll(),Messages.OperationClaimListed);
        }

        //public IDataResult<OperationClaim> GetByOperationClaim(int operationClaimId)
        //{
        //    return  new SuccessDataResult<OperationClaim>(_operationClaimDal.Get(oc=>oc.Id == operationClaimId));
        //}
    }
}
