using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class BasketDetailRepository : EfEntityRepositoryBase<BasketDetail, EticaretContext>, IBasketDetailRepository
    {
        public BasketDetailRepository(EticaretContext context) : base(context)
        {
        }
    }
}
