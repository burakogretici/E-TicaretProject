using AutoMapper;
using Business.Handlers.UserOperationClaims.Commands;
using Entities.Concrete;
using Entities.Dtos.UserOperationClaim;

namespace Business.Helpers.AutoMapperProfiles
{
    public class UserOperationClaimProfile : Profile
    {
        public UserOperationClaimProfile()
        {

            CreateMap<UserOperationClaim, UserOperationClaimDto>().ReverseMap();
            CreateMap<UserOperationClaim, DeleteUserOperationCLaimDto>().ReverseMap();


            CreateMap<UserOperationClaim, CreateUserOperationClaimCommand>().ReverseMap();
            CreateMap<UserOperationClaim, DeleteUserOperationClaimCommand>().ReverseMap();
            CreateMap<UserOperationClaim, UpdateUserOperationClaimCommand>().ReverseMap();


            CreateMap<UserOperationClaimDto, CreateUserOperationClaimCommand>().ReverseMap();
            CreateMap<UserOperationClaimDto, DeleteUserOperationClaimCommand>().ReverseMap();
            CreateMap<UserOperationClaimDto, UpdateUserOperationClaimCommand>().ReverseMap();

            CreateMap<DeleteUserOperationCLaimDto, DeleteUserOperationClaimCommand>().ReverseMap();


        }
    }
}