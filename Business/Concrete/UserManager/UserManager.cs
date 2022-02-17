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
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }

        public async Task<IDataResult<User>> GetByMail(string email)
        {
            return new SuccessDataResult<User>(await _userDal.GetAsync(u => u.Email == email));
        }

        public IDataResult<IEnumerable<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<IEnumerable<OperationClaim>>(_userDal.GetClaims(user));
        }

        public async Task<IDataResult<IEnumerable<User>>> GetAllAsync()
        {
            return new SuccessDataResult<IEnumerable<User>>(await _userDal.GetAllAsync(), Messages.UserListed);
        }

    }
}
