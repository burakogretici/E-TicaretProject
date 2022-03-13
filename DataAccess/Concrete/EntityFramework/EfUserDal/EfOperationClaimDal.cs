using Core.DataAccess.EntityFramework;
using DataAccess.Abstract.UserDal;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework.EfUserDal
{
    public class EfOperationClaimDal : EfEntityRepositoryBase<OperationClaim,EticaretContext>, IOperationClaimDal
    {
    }
}
