using System.Collections.Generic;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract.UserService
{
    public interface IUserService
    {
        IResult Add(User user);
        IResult Update(User country);
        IResult Delete(User country);

        IDataResult<IEnumerable<User>> GetAll();
        //IDataResult<User> GetById(int id);

        IDataResult<User> GetByMail(string email);
        IDataResult<IEnumerable<OperationClaim>> GetClaims(User user);

    }
}
