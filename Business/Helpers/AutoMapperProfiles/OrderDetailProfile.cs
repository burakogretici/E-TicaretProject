using AutoMapper;
using Business.Handlers.OrderDetails.Commands;
using Entities.Concrete;
using Entities.Dtos.Orders;

namespace Business.Helpers.AutoMapperProfiles
{
    public class OrderDetailProfile : Profile
    {
        public OrderDetailProfile()
        {
            CreateMap<OrderDetail, OrderDetailDto>().ReverseMap();
            CreateMap<OrderDetail, CreateOrderDetailCommand>().ReverseMap();
            CreateMap<OrderDetail, DeleteOrderDetailCommand>().ReverseMap();
            CreateMap<OrderDetail, UpdateOrderDetailCommand>().ReverseMap();
        }
    }
}