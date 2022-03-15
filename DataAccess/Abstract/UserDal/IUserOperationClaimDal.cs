using Core.DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Abstract.UserDal
{
    public interface IUserOperationClaimDal : IEntityRepository<UserOperationClaim>, IEntityAsyncRepository<UserOperationClaim>
    {
    }
}
