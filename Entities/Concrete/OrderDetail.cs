using System;
using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class OrderDetail : IEntity
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Amount { get; set; }
        public int SalePrice { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }


    }
}
