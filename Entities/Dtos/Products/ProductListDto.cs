using System;

namespace Entities.Dtos.Products
{
    public class ProductListDto : BaseDto
    {
        public string Name { get; set; }
        public string BrandName { get; set; }
        public string CategoryName { get; set; }
        public string ColorName { get; set; }
        public string SupplierName { get; set; }
        public string Code { get; set; }
        public short UnitsInStock { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
