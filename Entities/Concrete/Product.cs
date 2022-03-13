using System;
using System.Collections.Generic;
using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
        public Guid SupplierId { get; set; }
        public Guid BrandId { get; set; }
        public Guid ColorId { get; set; }
        public string Code { get; set; }
        public short UnitsInStock { get; set; }
        public decimal UnitPrice { get; set; }

        public Category Category { get; set; }
        public Supplier Supplier { get; set; }
        public Brand Brand { get; set; }
        public Color Color { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
        public ICollection<BasketDetail> BasketDetails { get; set; }
    }
}
