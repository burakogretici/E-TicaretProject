using AutoMapper;
using Business.Handlers.Suppliers.Commands;
using Entities.Concrete;
using Entities.Dtos.Suppliers;

namespace Business.Helpers.AutoMapperProfiles
{
    public class SupplierProfile : Profile
    {
        public SupplierProfile()
        {
            CreateMap<Supplier, SupplierDto>().ReverseMap();

            CreateMap<Supplier, CreateSupplierCommand>().ReverseMap();
            CreateMap<Supplier, DeleteSupplierCommand>().ReverseMap();
            CreateMap<Supplier, UpdateSupplierCommand>().ReverseMap();

        }
    }
}