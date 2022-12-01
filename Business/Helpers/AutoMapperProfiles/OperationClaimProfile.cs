using AutoMapper;
using Business.Handlers.OperationClaims.Commands;
using Entities.Concrete;
using Entities.Dtos.OperationClaims;

namespace Business.Helpers.AutoMapperProfiles
{
    public class OperationClaimProfile : Profile
    {
        public OperationClaimProfile()
        {

            CreateMap<OperationClaim, OperationClaimDto>().ReverseMap();

            CreateMap<OperationClaim, CreateOperationClaimCommand>().ReverseMap();
            CreateMap<OperationClaim, DeleteOperationClaimCommand>().ReverseMap();
            CreateMap<OperationClaim, UpdateOperationClaimCommand>().ReverseMap();

            CreateMap<OperationClaimDto, CreateOperationClaimCommand>().ReverseMap();
            CreateMap<OperationClaimDto, DeleteOperationClaimCommand>().ReverseMap();
            CreateMap<OperationClaimDto, UpdateOperationClaimCommand>().ReverseMap();

        }
    }
}