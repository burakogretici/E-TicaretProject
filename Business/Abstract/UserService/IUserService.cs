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

        IDataResult<List<User>> GetAll();
        //IDataResult<User> GetById(int id);

        IDataResult<User> GetByMail(string email);
        IDataResult<List<OperationClaim>> GetClaims(User user);

    }
}
