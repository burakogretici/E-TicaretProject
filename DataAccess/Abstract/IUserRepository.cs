using System.Collections.Generic;
using System.Threading.Tasks;
using Core.DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IUserRepository : IEntityAsyncRepository<User>
    {
        Task<IEnumerable<OperationClaim>> GetClaims(User user);
    }
}