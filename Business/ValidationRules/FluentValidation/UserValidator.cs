﻿using Entities.Dtos.Users;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<UserForRegister>
    {
        public UserValidator()
        {

            RuleFor(request => request.FirstName)
                .NotEmpty()
                .MinimumLength(2).WithMessage("First name must be a minimum of 2 characters.")
                .MaximumLength(30).WithMessage("First name must be a maximum of 30 characters.");


            RuleFor(request => request.LastName)
                .NotEmpty()
                .MaximumLength(20).WithMessage("Last name must be a maximum of 20 characters.");

            RuleFor(request => request.Email)
                .NotEmpty()
                .MaximumLength(40).WithMessage("Email must be a maximum of 40 characters.")
                .EmailAddress().WithMessage("A valid email is required");



            RuleFor(request => request.Password)
                .NotEmpty()
                .MinimumLength(8).WithMessage("Password must be a minimum of 8 characters.")
                .MaximumLength(20).WithMessage("Password must be a maximum of 20 characters.")
                .Matches("[A-Z]").WithMessage("'Password' must contain one or more capital letters.")
                .Matches("[a-z]").WithMessage("'Password' must contain one or more lowercase letters.")
                .Matches(@"\d").WithMessage("'Password' must contain one or more digits.")
                .Matches(@"[][""!@$%^&*(){}:;<>,.?/+_=|'~\\-]")
                .WithMessage("'Password' must contain one or more special characters.");


            //RuleFor(request => request.Phone)
            //    .NotEmpty()
            //    .MinimumLength(8).WithMessage("Phone number must be a maximum of 8 characters.")
            //    .Matches(@"^((?:[0-9]\-?){6,14}[0-9])|((?:[0-9]\x20?){6,14}[0-9])$")
            //    .WithMessage("'Phone' must contain valid phone number.")
            //    .MaximumLength(30).WithMessage("Phone number must be a maximum of 30 characters.");

        }
    }
}
