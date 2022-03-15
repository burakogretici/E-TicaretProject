using Core.DataAccess.EntityFramework;
using DataAccess.Abstract.UserDal;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework.EfUserDal
{
    public class EfUserOperationClaimDal : EfEntityRepositoryBase<UserOperationClaim, EticaretContext>,IUserOperationClaimDal
    {
        public EfUserOperationClaimDal(EticaretContext context) : base(context)
        {
        }
    }
}
