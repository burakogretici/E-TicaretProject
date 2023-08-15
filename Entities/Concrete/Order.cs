using System;
using System.Collections.Generic;
using Core.Entities.Concrete;
using Entities.Enums;

namespace Entities.Concrete
{
    public class Order : BaseEntity<Guid>
    {
        public Guid UserId { get; set; }
        public Guid AddressId { get; set; }
        public Guid ShipperId { get; set; }
        public Guid BasketId { get; set; }

        //public int Amount { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public virtual User User { get; set; }
        public virtual Shipper Shipper { get; set; }
        public virtual Address Address { get; set; }
        public virtual Basket Basket { get; set; }

    }


}
