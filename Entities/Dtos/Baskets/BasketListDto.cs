namespace Entities.Dtos.Baskets
{
    public class BasketListDto : BaseDto
    {
        public string CustomerName { get; set; }
        public string ProductName { get; set; }
        public float Amount { get; set; }
        public float Price { get; set; }
      

    }
}
