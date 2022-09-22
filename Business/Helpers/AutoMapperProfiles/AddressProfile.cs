using AutoMapper;
using Business.Handlers.Addresses.Commands;
using Entities.Concrete;
using Entities.Dtos.Addresses;

namespace Business.Helpers.AutoMapperProfiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<Address, CreateAddressCommand>().ReverseMap();
            CreateMap<Address, DeleteAddressCommand>().ReverseMap();
            CreateMap<Address, UpdateAddressCommand>().ReverseMap();
            CreateMap<AddressDto,CreateAddressCommand>().ReverseMap();
            CreateMap<AddressDto, DeleteAddressCommand>().ReverseMap();
            CreateMap<AddressDto, UpdateAddressCommand>().ReverseMap();
        }
    }
}
