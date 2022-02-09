using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Helpers.AutoMapperProfiles
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<CountryDto, Country>().ReverseMap();
        }
    }
}
