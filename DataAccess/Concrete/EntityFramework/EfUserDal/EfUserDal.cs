using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract.UserDal;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework.EfUserDal
{
    public class EfUserDal : EfEntityRepositoryBase<User, EticaretContext>, IUserDal
    {
        public EfUserDal(EticaretContext context) : base(context)
        {
        }
        public List<OperationClaim> GetClaims(User user)
        {
            //using (var context = new EticaretContext())
            //{
            //    var result = from operationClaim in context.OperationClaims
            //                 join userOperationClaim in context.UserOperationClaims
            //                     on operationClaim.Id equals userOperationClaim.OperationClaimId
            //                 where userOperationClaim.UserId == user.Id
            //                 select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
            //    return result.ToList();

            //}
            return null;
        }


    }
}
