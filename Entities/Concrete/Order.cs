using System;
using System.Collections.Generic;
using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class Order : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid AddressId { get; set; }
        public Guid OrderStatusId { get; set; }
        public int Count { get; set; }
        public User User { get; set; }
        public Address Address { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
