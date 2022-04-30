using System;
using System.Collections.Generic;
using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class Brand : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
