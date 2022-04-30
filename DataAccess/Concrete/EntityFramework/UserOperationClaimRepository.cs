using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class UserOperationClaimRepository : EfEntityRepositoryBase<UserOperationClaim, EticaretContext>,IUserOperationClaimRepository
    {
        public UserOperationClaimRepository(EticaretContext context) : base(context)
        {
        }
    }
}
