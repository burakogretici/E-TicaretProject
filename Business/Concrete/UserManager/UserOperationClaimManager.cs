using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Abstract.UserService;
using Business.Constants;
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

        public async Task<IDataResult<IEnumerable<UserOperationClaim>>> GetAllAsync()
        {
            return new SuccessDataResult<IEnumerable<UserOperationClaim>>(await _userOperationClaimDal.GetAllAsync(), Messages.UserOperationClaimListed);
        }
        public async Task<IDataResult<UserOperationClaim>> GetByOperationClaim(Guid operationClaimId)
        {
            return new SuccessDataResult<UserOperationClaim>(await _userOperationClaimDal.GetAsync(uoc => uoc.OperationClaimId == operationClaimId));
        }

        //public IDataResult<UserOperationClaim> GetByUserOperationClaim(int userOperationClaimId)
        //{
        //    return new SuccessDataResult<UserOperationClaim>(_userOperationClaimDal.Get(uoc => uoc.Id == userOperationClaimId));
        //}

    }
}
