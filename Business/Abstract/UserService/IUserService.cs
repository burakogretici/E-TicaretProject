using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract.UserService
{
    public interface IUserService
    {
        IResult Add(User user);
        IResult Update(User country);
        IResult Delete(User country);

        Task<IDataResult<IEnumerable<User>>> GetAllAsync();
        //IDataResult<User> GetById(int id);

        Task<IDataResult<User>> GetByMail(string email);
        IDataResult<IEnumerable<OperationClaim>> GetClaims(User user);

    }
}
