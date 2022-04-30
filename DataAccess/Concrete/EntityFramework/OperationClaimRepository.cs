using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class OperationClaimRepository : EfEntityRepositoryBase<OperationClaim,EticaretContext>, IOperationClaimRepository
    {
        public OperationClaimRepository(EticaretContext context) : base(context)
        {
        }
    }
}
