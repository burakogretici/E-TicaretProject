using System;
using Core.Entities.Abstract;
using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class OrderDetail : BaseEntity<Guid>
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Amount { get; set; }
        public int SalePrice { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }


    }
}
