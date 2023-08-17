using System;
using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class BasketItem : BaseEntity<Guid>
    {
        public Guid BasketId { get; set; }
        public Guid ProductId { get; set; }
        public float Amount { get; set; }
        public decimal Price { get; set; }
        
        public virtual Basket Basket { get; set; }
        public virtual Product Product { get; set; }

    }
}
