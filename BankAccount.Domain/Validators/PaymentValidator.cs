using BankAccount.Domain.Entities;
using FluentValidation;


namespace BankAccount.Domain.Validators
{
    public class PaymentValidator : AbstractValidator<Payment>
    {
        public PaymentValidator() 
        {
            RuleFor(x => x.Source).SetInheritanceValidator(v =>
            {
                v.Add(new UserValidator());
            });
            RuleFor(x => x.Destination)
                .NotEmpty().WithMessage("Insira um destino válido.")
                .NotNull().WithMessage("Insira um destino válido.");
        }
    }
}
