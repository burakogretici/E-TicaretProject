using AutoMapper;
using Entities.Concrete;
using Entities.DTOs.Users;

namespace Business.Helpers.AutoMapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            //Register
            CreateMap<User, UserForRegister>().ReverseMap();
            CreateMap<UserForRegister, User>().ReverseMap();

            //Login
            CreateMap<User, UserForLogin>().ReverseMap();
            CreateMap<UserForLogin, User>().ReverseMap();
        }
    }
}
