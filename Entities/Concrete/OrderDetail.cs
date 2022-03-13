using System;
using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class OrderDetail : BaseEntity
    {

        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Count { get; set; }
        public int SalePrice { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }


    }
}
