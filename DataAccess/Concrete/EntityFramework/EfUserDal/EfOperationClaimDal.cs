using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract.UserDal;

namespace DataAccess.Concrete.EntityFramework.EfUserDal
{
    public class EfOperationClaimDal : EfEntityRepositoryBase<OperationClaim,EticaretContext>, IOperationClaimDal
    {
    }
}
