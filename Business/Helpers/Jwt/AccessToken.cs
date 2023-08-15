using Entities.Dtos.Users;
using System;

namespace Business.Helpers.Jwt
{
    public class AccessToken
    {
        public UserDto User { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
       
    }
}
