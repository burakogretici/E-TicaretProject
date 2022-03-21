using System;
using System.Collections.Generic;
using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class Basket : BaseEntity
    {
        public Guid CustomerId { get; set; }

        public Customer Customer { get; set; }
        public ICollection<BasketDetail> BasketDetails { get; set; }
    }
}
