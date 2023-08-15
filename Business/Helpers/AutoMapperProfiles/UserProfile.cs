using AutoMapper;
using Business.Handlers.Authorizations.Commands;
using Business.Handlers.Authorizations.Queries;
using Business.Handlers.Users.Commands;
using Core.Utilities.Results.Paging;
using Entities.Concrete;
using Entities.Dtos.UserOperationClaim;
using Entities.Dtos.Users;

namespace Business.Helpers.AutoMapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<PaginatedResult<User>, PaginatedResult<UserDto>>().ReverseMap();

            CreateMap<User, CreateUserCommand>().ReverseMap();
            CreateMap<User, RegisterUserCommand>().ReverseMap();
            CreateMap<User, DeleteUserCommand>().ReverseMap();
            CreateMap<User, UpdateUserCommand>().ReverseMap();
            CreateMap<User, LoginUserQuery>().ReverseMap();

            CreateMap<UserDto, CreateUserCommand>().ReverseMap();
            CreateMap<UserDto, RegisterUserCommand>().ReverseMap();
            CreateMap<UserDto, DeleteUserCommand>().ReverseMap();
            CreateMap<UserDto, UpdateUserCommand>().ReverseMap();
            CreateMap<UserDto, LoginUserQuery>().ReverseMap();

            CreateMap<User, UserForLogin>().ReverseMap();
            CreateMap<User, UserForRegister>().ReverseMap();
            CreateMap<User, UserOperationClaimDto>().ReverseMap();


            CreateMap<UserDto, UserForRegister>().ReverseMap();
            CreateMap<UserDto, UserForRegister>().ReverseMap();

            CreateMap<UserForLogin, LoginUserQuery>().ReverseMap();
            CreateMap<UserForRegister, RegisterUserCommand>().ReverseMap();

            CreateMap<User, UserDto>().ReverseMap();


        }
    }
}
