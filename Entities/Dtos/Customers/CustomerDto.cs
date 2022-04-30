using Entities.Enums;

namespace Entities.Dtos.Customers
{
    public class CustomerDto : BaseDto
    {
        public string CustomerFullName { get; set; }
        public CustomerType CustomerType { get; set; }

    }
}
