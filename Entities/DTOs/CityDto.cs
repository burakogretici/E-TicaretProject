using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Abstract;

namespace Entities.DTOs
{
    public class CityDto : IDto
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
    }
}
