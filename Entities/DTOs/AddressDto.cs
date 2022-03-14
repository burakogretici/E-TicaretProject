using System;
using Core.Entities.Abstract;

namespace Entities.DTOs
{
    public class AddressDto : IDto
    {
        public Guid UserId { get; set; }
        public Guid CountryId { get; set; }
        public Guid CityId { get; set; }
        public string AddressDetail { get; set; }
        public string PostalCode { get; set; }
    }
}
