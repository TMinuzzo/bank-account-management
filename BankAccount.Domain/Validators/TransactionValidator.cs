using BankAccount.Domain.Entities;
using FluentValidation;


namespace BankAccount.Domain.Validators
{
    public class TransactionValidator : AbstractValidator<TransactionBase>
    {
        public TransactionValidator()
        {
            RuleFor(v => v.Amount)
                .NotEmpty().WithMessage("Insira um valor válido")
                .NotNull().WithMessage("Insira um valor válido")
                .GreaterThan(0).WithMessage("Insira um valor maior que 0");
        }
    }
}
