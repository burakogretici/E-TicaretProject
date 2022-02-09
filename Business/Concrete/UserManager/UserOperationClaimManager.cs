using System.Collections.Generic;
using Business.Abstract.UserService;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract.UserDal;
using Entities.Concrete;

namespace Business.Concrete.UserManager
{
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        private readonly IUserOperationClaimDal _userOperationClaimDal;

        public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal)
        {
            _userOperationClaimDal = userOperationClaimDal;
        }

        public IResult Add(UserOperationClaim userOperationClaim)
        {
            _userOperationClaimDal.Add(userOperationClaim);
            return new SuccessResult(Messages.UserOperationClaimAdded);
        }

        public IResult Update(UserOperationClaim userOperationClaim)
        {
            _userOperationClaimDal.Update(userOperationClaim);
            return new SuccessResult(Messages.UserOperationClaimAdded);
        }

        public IResult Delete(UserOperationClaim userOperationClaim)
        {
            _userOperationClaimDal.Update(userOperationClaim);
            return new SuccessResult(Messages.UserOperationClaimAdded);
        }

        public IDataResult<IEnumerable<UserOperationClaim>> GetAll()
        {
            return new SuccessDataResult<IEnumerable<UserOperationClaim>>(_userOperationClaimDal.GetAll(),Messages.UserOperationClaimListed);
        }

        //public IDataResult<UserOperationClaim> GetByUserOperationClaim(int userOperationClaimId)
        //{
        //    return new SuccessDataResult<UserOperationClaim>(_userOperationClaimDal.Get(uoc => uoc.Id == userOperationClaimId));
        //}

        public IDataResult<UserOperationClaim> GetByOperationClaim(int operationClaimId)
        {
            return new SuccessDataResult<UserOperationClaim>(_userOperationClaimDal.Get(uoc => uoc.OperationClaimId == operationClaimId));
        }
    }
}
