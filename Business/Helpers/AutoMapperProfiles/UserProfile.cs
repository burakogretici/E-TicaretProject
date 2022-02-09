using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.DTOs;

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
