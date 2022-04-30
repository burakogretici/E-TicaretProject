using System;
using System.Collections.Generic;
using Core.Entities.Concrete;
using Entities.Enums;

namespace Entities.Concrete
{
    public class Customer : BaseEntity<Guid>
    {
        public Guid UserId { get; set; }
        public CustomerType CustomerType { get; set; }

        public virtual User User { get; set; }
        
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Basket> Baskets { get; set; }
        public virtual ICollection<Supplier> Suppliers { get; set; }
        public virtual ICollection<Individual> Individuals { get; set; }

    }
}
