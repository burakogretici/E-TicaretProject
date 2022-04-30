using System;
using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class BasketDetail : BaseEntity<Guid>
    {
        public Guid BasketId { get; set; }
        public Guid ProductId { get; set; }
        public float Amount { get; set; }
        public float Price { get; set; }
        public float Total { get; set; }

        public virtual Basket Basket { get; set; }
        public virtual Product Product { get; set; }

    }
}
