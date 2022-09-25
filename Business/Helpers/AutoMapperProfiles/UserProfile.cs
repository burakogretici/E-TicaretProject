using AutoMapper;
using Business.Handlers.Authorizations.Commands;
using Business.Handlers.Users.Commands;
using Entities.Concrete;
using Entities.Dtos.Users;

namespace Business.Helpers.AutoMapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, CreateUserCommand>().ReverseMap();
            CreateMap<User, RegisterUserCommand>().ReverseMap();
            CreateMap<User, DeleteUserCommand>().ReverseMap();
            CreateMap<User, UpdateUserCommand>().ReverseMap();
            CreateMap<User, LoginUserCommand>().ReverseMap();

            CreateMap<UserDto, CreateUserCommand>().ReverseMap();
            CreateMap<UserDto, RegisterUserCommand>().ReverseMap();
            CreateMap<UserDto, DeleteUserCommand>().ReverseMap();
            CreateMap<UserDto, UpdateUserCommand>().ReverseMap();
            CreateMap<UserDto, LoginUserCommand>().ReverseMap();

            CreateMap<User, UserForLogin>().ReverseMap();
            CreateMap<User, UserForRegister>().ReverseMap();

            CreateMap<UserDto, UserForRegister>().ReverseMap();
            CreateMap<UserDto, UserForRegister>().ReverseMap();

            CreateMap<UserForLogin, LoginUserCommand>().ReverseMap();
            CreateMap<UserForRegister, RegisterUserCommand>().ReverseMap();

            CreateMap<User, UserDto>().ReverseMap();


        }
    }
}
