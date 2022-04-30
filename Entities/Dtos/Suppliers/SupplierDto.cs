using System;

namespace Entities.Dtos.Suppliers
{
    public class SupplierDto
    {
        public Guid Id { get; set; }
        public string CustomerFullName { get; set; }
        public string CompanyName { get; set; }
        public string Fax { get; set; }
        public string Website { get; set; }
    }
}
