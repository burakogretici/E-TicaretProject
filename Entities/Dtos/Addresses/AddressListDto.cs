namespace Entities.Dtos.Addresses
{
    public class AddressListDto : BaseDto
    {
        public string CustomerName { get; set; }
        public string CustomerLastName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string AddressDetail { get; set; }
        public string PostalCode { get; set; }
    }
}
