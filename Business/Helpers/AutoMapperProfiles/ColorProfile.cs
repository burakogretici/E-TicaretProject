using AutoMapper;
using Entities.Concrete;
using Entities.DTOs;
using Entities.DTOs.Colors;

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
