using System;
using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class BasketDetail : BaseEntity
    {
        public Guid BasketId { get; set; }
        public Guid ProductId { get; set; }
        public float Amount { get; set; }
        public float Price { get; set; }
        public float Total { get; set; }

        public Basket Basket { get; set; }
        public Product Product { get; set; }

    }
}
