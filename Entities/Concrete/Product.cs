using System;
using System.Collections.Generic;
using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class Product : BaseEntity<Guid>
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
            BasketDetails = new HashSet<BasketDetail>();
        }
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
        public Guid SupplierId { get; set; }
        public Guid BrandId { get; set; }
        public Guid ColorId { get; set; }
        public string Code { get; set; }
        public short UnitsInStock { get; set; }
        public decimal UnitPrice { get; set; }

        public virtual Category Category { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual Color Color { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<BasketDetail> BasketDetails { get; set; }
    }
}
