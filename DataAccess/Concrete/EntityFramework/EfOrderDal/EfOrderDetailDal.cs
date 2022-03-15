using Core.DataAccess.EntityFramework;
using DataAccess.Abstract.OrderDal;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework.EfOrderDal
{
    public class EfOrderDetailDal : EfEntityRepositoryBase<OrderDetail, EticaretContext>, IOrderDetailDal
    {
        public EfOrderDetailDal(EticaretContext context) : base(context)
        {
        }
    }
}
