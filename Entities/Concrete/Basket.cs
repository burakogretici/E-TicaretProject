using System;
using System.Collections.Generic;
using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class Basket : BaseEntity<Guid>
    {
        public Basket()
        {
            BasketDetails = new HashSet<BasketDetail>();
        }
        public Guid CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<BasketDetail> BasketDetails { get; set; }
    }
}
