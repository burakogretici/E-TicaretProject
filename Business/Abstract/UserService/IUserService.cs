using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract.UserService
{
    public interface IUserService
    {
        Task<IResult> AddAsync(User user);
        Task<IResult> UpdateAsync(User country);
        Task<IResult> DeleteAsync(User country);

        Task<IDataResult<IEnumerable<User>>> GetAllAsync();
        //IDataResult<User> GetById(int id);

        Task<IDataResult<User>> GetByMail(string email);
        Task<IDataResult<IEnumerable<OperationClaim>>> GetClaims(User user);

    }
}
