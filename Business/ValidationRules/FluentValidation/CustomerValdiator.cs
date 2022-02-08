using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValdiator : AbstractValidator<Customer>
    {
        public CustomerValdiator()
        {

        }
    }
}
