using System;
using System.Collections.Generic;
using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class Shipper : BaseEntity<Guid>
    {
        public Shipper()
        {
            Orders = new HashSet<Order>();
        }
        public string Name { get; set; }
        public string? Phone { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
