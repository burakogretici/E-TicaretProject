using System;


namespace Entities.Dtos.Products
{
    public class ProductDto : BaseDto
    {
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
        public Guid BrandId { get; set; }
        public Guid ColorId { get; set; }
        public Guid SupplierId { get; set; }
    
        public string Code { get; set; }
        public short UnitsInStock { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
