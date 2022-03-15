using Core.Entities.Abstract;

namespace Entities.DTOs.Customers
{
    public class CustomerDetailDto : IDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

    }
}
