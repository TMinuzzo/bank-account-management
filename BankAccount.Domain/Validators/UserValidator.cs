using BankAccount.Domain.Entities;
using FluentValidation;


namespace BankAccount.Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("Insira um nome válido");
            RuleFor(v => v.Balance)
                .GreaterThanOrEqualTo(0).WithMessage("Não foi possível realizar a transação: Saldo insuficiente");
        }
    }
}
