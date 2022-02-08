using Core.Entities.Concrete;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
   public class UserValdiator : AbstractValidator<User>
    {
        public UserValdiator()
        {

        }
    }
}
