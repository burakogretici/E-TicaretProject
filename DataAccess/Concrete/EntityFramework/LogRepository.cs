using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class LogRepository : EfEntityRepositoryBase<Log, EticaretContext>, ILogRepository
    {
        public LogRepository(EticaretContext context)
            : base(context)
        {
        }
    }
}