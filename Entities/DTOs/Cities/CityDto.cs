using System;

namespace Entities.Dtos.Cities
{
    public class CityDto : BaseDto
    {
        public Guid CountryId { get; set; }
        public string Name { get; set; }
    }
}
