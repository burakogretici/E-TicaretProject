using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    
    public class UserRepository : EfEntityRepositoryBase<User, EticaretContext>, IUserRepository
    {
        public UserRepository(EticaretContext context) : base(context)
        {
        }

        public async Task<IEnumerable<OperationClaim>> GetClaims(User user)
        {
            var list = await (from operationClaim in Context.OperationClaims
                              join userOperationClaim in Context.UserOperationClaims
                                  on operationClaim.Id equals userOperationClaim.OperationClaimId
                              where userOperationClaim.UserId == user.Id
                              select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name }).ToListAsync();

            return list;

        }


    }
}
