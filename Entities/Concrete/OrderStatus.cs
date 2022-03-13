using System.Collections.Generic;
using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class OrderStatus : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
