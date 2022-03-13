using Core.Entities.Abstract;

namespace Entities.DTOs
{
    public class CityDto : IDto
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
    }
}
