using AutoMapper;
using Business.Handlers.Colors.Commands;
using Core.Utilities.Results.Paging;
using Entities.Concrete;
using Entities.Dtos.Colors;

namespace Business.Helpers.AutoMapperProfiles
{
    public class ColorProfile : Profile
    {
        public ColorProfile()
        {
            CreateMap<Color, ColorDto>().ReverseMap();

            CreateMap<PaginatedResult<Color>, PaginatedResult<ColorDto>>().ReverseMap();


            CreateMap<Color, CreateColorCommand>().ReverseMap();
            CreateMap<Color, DeleteColorCommand>().ReverseMap();
            CreateMap<Color, UpdateColorCommand>().ReverseMap();

            CreateMap<ColorDto, CreateColorCommand>().ReverseMap();
            CreateMap<ColorDto, DeleteColorCommand>().ReverseMap();
            CreateMap<ColorDto, UpdateColorCommand>().ReverseMap();
        }
    }
}
