using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract.OrderDal;
using Entities.Concrete;


namespace DataAccess.Concrete.EntityFramework.EfOrderDal
{
    public class EfOrderStatusDal : EfEntityRepositoryBase<OrderStatus, EticaretContext>, IOrderStatusDal
    {
    }
}
