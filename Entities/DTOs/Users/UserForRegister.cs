using Core.Entities.Abstract;

namespace Entities.Dtos.Users
{
    public class UserForRegister : IDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
    