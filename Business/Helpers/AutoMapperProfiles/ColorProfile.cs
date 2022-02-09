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
    public class ColorProfile : Profile
    {
        public ColorProfile()
        {
            CreateMap<Color, ColorDto>().ReverseMap();
            CreateMap<ColorDto, Color>().ReverseMap();
        }
    }
}
