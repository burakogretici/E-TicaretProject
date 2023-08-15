using Entities.Dtos.Orders;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class OrderValidator : AbstractValidator<OrderDto>
    {
        public OrderValidator()
        {

        }
    }
}
