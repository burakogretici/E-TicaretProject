using System;

namespace Entities.Dtos.Addresses
{
    public class AddressDto : BaseDto
    {
        public Guid UserId { get; set; }
        public Guid CountryId { get; set; }
        public Guid CityId { get; set; }
        public string AddressDetail { get; set; }
        public string PostalCode { get; set; }
    }
}
