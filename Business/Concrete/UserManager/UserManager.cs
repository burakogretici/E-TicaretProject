using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;
using Business.Abstract.UserService;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract.UserDal;
using Entities.Concrete;

namespace Business.Concrete.UserManager
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public async Task<IResult> DeleteAsync(User user)
        {
            await _userDal.DeleteAsync(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public async Task<IResult> AddAsync(User user)
        {
            await _userDal.AddAsync(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public async Task<IResult> UpdateAsync(User user)
        {
            await _userDal.UpdateAsync(user);
            return new SuccessResult(Messages.UserUpdated);
        }

        public async Task<IDataResult<User>> GetByMail(string email)
        {
            return new SuccessDataResult<User>(await _userDal.GetAsync(u => u.Email == email));
        }

        public async Task<IDataResult<IEnumerable<OperationClaim>>> GetClaims(User user)
        {
            var result = await _userDal.GetClaims(user);
            return new SuccessDataResult<IEnumerable<OperationClaim>>(result);
        }

        public async Task<IDataResult<IEnumerable<User>>> GetAllAsync()
        {
            return new SuccessDataResult<IEnumerable<User>>(await _userDal.GetAllAsync(), Messages.UserListed);
        }

    }
}
