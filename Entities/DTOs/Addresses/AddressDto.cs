namespace Entities.Dtos.Addresses
{
    public class AddressDto : BaseDto
    {
        public string CustomerFullName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string AddressDetail { get; set; }
        public string PostalCode { get; set; }
    }
}
