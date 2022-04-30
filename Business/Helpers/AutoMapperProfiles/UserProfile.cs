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
            //Register
            CreateMap<User, CreateUserCommand>().ReverseMap();
            CreateMap<User, RegisterUserCommand>().ReverseMap();
            CreateMap<User, DeleteUserCommand>().ReverseMap();
            CreateMap<User, UpdateUserCommand>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();

            //Login
            CreateMap<User, UserForLogin>().ReverseMap();
            CreateMap<UserForLogin, User>().ReverseMap();
        }
    }
}
