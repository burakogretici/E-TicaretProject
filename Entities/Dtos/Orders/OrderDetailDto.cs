using System;

namespace Entities.Dtos.Orders
{
    public class OrderDetailDto  
    { 
        public string OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Amount { get; set; }
        public int SalePrice { get; set; }
    }
}
