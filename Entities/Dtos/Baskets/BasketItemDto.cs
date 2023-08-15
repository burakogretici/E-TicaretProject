using System;

namespace Entities.Dtos.Baskets
{
    public class BasketItemDto : BaseDto
    {
        public Guid BasketId { get; set; }
        public Guid ProductId { get; set; }
        public float Amount { get; set; }
        //public float Price { get; set; }
        //public float Total { get; set; }

    }
}
