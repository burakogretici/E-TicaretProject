using AutoMapper;
using Entities.Concrete;
using Entities.DTOs.Categories;

namespace Business.Helpers.AutoMapperProfiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<CategoryDto, Category>().ReverseMap();
        }
    }
}