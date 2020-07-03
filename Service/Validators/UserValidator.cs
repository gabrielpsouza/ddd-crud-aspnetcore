using Domain.Entities;
using FluentValidation;
using System;

namespace Service.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(c => c)
                .NotNull()
                .OnAnyFailure(x =>
                {
                    throw new ArgumentNullException("Not found Data");
                });

            RuleFor(c => c.CPF)
                .NotEmpty().WithMessage("Is necessary to inform the CPF.")
                .NotNull().WithMessage("Is necessary to inform the CPF.");

            RuleFor(c => c.BirthDate)
                .NotEmpty().WithMessage("Is necessary to inform the birth date.")
                .NotNull().WithMessage("Is necessary to inform the birth date.");

            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Is necessary to inform the name.")
                .NotNull().WithMessage("Is necessary to inform the name.");
        }
    }
}
