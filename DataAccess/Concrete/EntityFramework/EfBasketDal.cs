using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBasketDal : EfEntityRepositoryBase<Basket, EticaretContext>, IBasketDal
    {
        public EfBasketDal(EticaretContext context) : base(context)
        {
        }
    }
}
