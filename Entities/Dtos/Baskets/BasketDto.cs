using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Entities.Dtos.Baskets
{
    public class BasketDto : BaseDto
    {
        public Guid UserId { get; set; }
       
        public virtual ICollection<BasketItem> BasketItems { get; set; }

    }
}
