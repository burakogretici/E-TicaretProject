using System;
using System.Collections.Generic;
using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class Category : BaseEntity<Guid>
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
