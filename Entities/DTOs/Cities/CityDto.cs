using System;
using Core.Entities.Abstract;

namespace Entities.DTOs.Cities
{
    public class CityDto : IDto
    {
        public Guid CountryId { get; set; }
        public string Name { get; set; }
    }
}
