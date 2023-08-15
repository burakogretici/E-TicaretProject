using System;
using System.Collections.Generic;
using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class Basket : BaseEntity<Guid>
    {
        public Basket()
        {
            BasketItems = new HashSet<BasketItem>();
            Orders = new HashSet<Order>();
        }

        public Guid UserId { get; set; }


        public virtual User User { get; set; }
        public virtual ICollection<BasketItem> BasketItems { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

    }

}
