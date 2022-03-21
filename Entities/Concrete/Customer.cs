using System;
using System.Collections.Generic;
using Core.Entities.Concrete;

namespace Entities.Concrete
{
    
    public class Customer : BaseEntity
    {
        public Guid UserId { get; set; }
        public Individual? Individual { get; set; }
        public Supplier? Supplier { get; set; }

        public ICollection<Address> Address { get; set; }
        public User User { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Basket> Baskets { get; set; }

    }
}
