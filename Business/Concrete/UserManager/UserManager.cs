using System.Collections.Generic;
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

        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
        }

        public IDataResult<IEnumerable<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<IEnumerable<OperationClaim>>(_userDal.GetClaims(user));
        }

        public IDataResult<IEnumerable<User>> GetAll()
        {
            return new SuccessDataResult<IEnumerable<User>>(_userDal.GetAll(), Messages.UserListed);
        }

    }
}
