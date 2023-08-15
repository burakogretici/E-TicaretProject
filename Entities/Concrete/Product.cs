using System;
using System.Collections.Generic;
using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class Product : BaseEntity<Guid>
    {
        public Product()
        {
            BasketItems = new HashSet<BasketItem>();
            ProductImages = new HashSet<ProductImage>();
        }
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
        public Guid BrandId { get; set; }
        public Guid ColorId { get; set; }
        public string Code { get; set; }
        public short UnitsInStock { get; set; }
        public decimal UnitPrice { get; set; }
        //public string Image { get; set; }

        public virtual Category Category { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual Color Color { get; set; }

        public virtual ICollection<ProductImage> ProductImages { get; set; }

        public virtual ICollection<BasketItem> BasketItems { get; set; }
    }
}
