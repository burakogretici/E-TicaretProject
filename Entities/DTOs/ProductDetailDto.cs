using Core.Entities.Abstract;

namespace Entities.DTOs
{
    public class ProductDetailDto : IDto
    {
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public decimal UnitPrice { get; set; }

    }
}
