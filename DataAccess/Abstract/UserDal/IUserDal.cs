using System.Collections.Generic;
using Core.DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Abstract.UserDal
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
