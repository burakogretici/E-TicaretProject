namespace Entities.Dtos.Addresses
{
    public class AddressListDto : BaseDto
    {
        public string FullName { get; set; }
        public string CountryName { get; set; }
        public string CityName { get; set; }
        public string AddressDetail { get; set; }
        public string PostalCode { get; set; }
    }
}
