using Entities.Enums;

namespace Entities.Dtos.Orders
{
    public class OrderDto : BaseDto
    { 
        public string CustomerFullName { get; set; }
        public string Address { get; set; }
        public string Shipper { get; set; }
        public int Amount { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
