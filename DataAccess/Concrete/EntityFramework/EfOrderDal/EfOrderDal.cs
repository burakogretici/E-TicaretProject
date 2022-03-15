using Core.DataAccess.EntityFramework;
using DataAccess.Abstract.OrderDal;
using Entities.Concrete;


namespace DataAccess.Concrete.EntityFramework.EfOrderDal
{
    public class EfOrderDal : EfEntityRepositoryBase<Order, EticaretContext>, IOrderDal
    {
        public EfOrderDal(EticaretContext context) : base(context)
        {
        }
    }
}
