namespace Entities.Dtos.Baskets
{
    public class BasketDto : BaseDto
    {
        public string CustomerName { get; set; }
        public string ProductName { get; set; }
        public float Amount { get; set; }
        public float Price { get; set; }
        public float Total { get; set; }
    }
}
