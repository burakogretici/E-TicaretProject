using AutoMapper;
using Business.Handlers.Shippers.Commands;
using Entities.Concrete;
using Entities.Dtos.Shippers;

namespace Business.Helpers.AutoMapperProfiles
{
    public class ShipperProfile : Profile
    {
        public ShipperProfile()
        {
            CreateMap<Shipper, ShipperDto>().ReverseMap();

            CreateMap<Shipper, CreateShipperCommand>().ReverseMap();
            CreateMap<Shipper, DeleteShipperCommand>().ReverseMap();
            CreateMap<Shipper, UpdateShipperCommand>().ReverseMap();

            CreateMap<ShipperDto, CreateShipperCommand>().ReverseMap();
            CreateMap<ShipperDto, DeleteShipperCommand>().ReverseMap();
            CreateMap<ShipperDto, UpdateShipperCommand>().ReverseMap();
        }
    }
}
