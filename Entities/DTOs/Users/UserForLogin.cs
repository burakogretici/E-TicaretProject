using Core.Entities.Abstract;

namespace Entities.Dtos.Users
{
    public class UserForLogin : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
