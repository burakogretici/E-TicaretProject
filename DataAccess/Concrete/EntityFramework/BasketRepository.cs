using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class BasketRepository : EfEntityRepositoryBase<Basket, EticaretContext>, IBasketRepository
    {
        public BasketRepository(EticaretContext context) : base(context)
        {
        }
    }
}
