using System.Collections.Generic;
using System.Threading.Tasks;
using Core.DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Abstract.UserDal
{
    public interface IUserDal : IEntityRepository<User>, IEntityAsyncRepository<User>
    {
        Task<List<OperationClaim>> GetClaims(User user);
    }
}
