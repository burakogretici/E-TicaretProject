using Core.DataAccess.EntityFramework;
using DataAccess.Abstract.OrderDal;
using Entities.Concrete;


namespace DataAccess.Concrete.EntityFramework.EfOrderDal
{
    public class EfOrderStatusDal : EfEntityRepositoryBase<OrderStatus, EticaretContext>, IOrderStatusDal
    {
    }
}
