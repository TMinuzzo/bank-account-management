using BankAccount.Domain.Entities;
using FluentValidation;


namespace BankAccount.Domain.Validators
{
    public class WithdrawValidator : AbstractValidator<Withdraw>
    {
        public WithdrawValidator()
        {
            RuleFor(x => x.Source).SetInheritanceValidator(v =>
            {
                v.Add(new UserValidator());
            });
        }
    }
}
