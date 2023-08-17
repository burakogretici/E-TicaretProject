using AutoMapper;
using Business.Handlers.BasketItems.Commands;
using Core.Utilities.Results.Paging;
using Entities.Concrete;
using Entities.Dtos.Baskets;
namespace Business.Helpers.AutoMapperProfiles
{
    public class BasketItemProfile : Profile
    {
        public BasketItemProfile()
        {
            CreateMap<BasketItem, BasketItemDto>().ReverseMap();

            CreateMap<BasketItem, BasketListDto>()
.ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Basket.User.FullName));

            CreateMap<PaginatedResult<BasketItem>, PaginatedResult<BasketListDto>>().ReverseMap();
            CreateMap<BasketItem, CreateBasketItemCommand>().ReverseMap();
            CreateMap<BasketItem, DeleteBasketItemCommand>().ReverseMap();
            CreateMap<BasketItem, UpdateBasketItemCommand>().ReverseMap();

            CreateMap<BasketItemDto, CreateBasketItemCommand>().ReverseMap();
            CreateMap<BasketItemDto, DeleteBasketItemCommand>().ReverseMap();
            CreateMap<BasketItemDto, UpdateBasketItemCommand>().ReverseMap();

        }
    }
}