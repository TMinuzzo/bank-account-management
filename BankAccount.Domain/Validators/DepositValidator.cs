using BankAccount.Domain.Entities;
using FluentValidation;


namespace BankAccount.Domain.Validators
{
    public class DepositValidator : AbstractValidator<Deposit>
    {
        public DepositValidator() 
        {
            RuleFor(x => x.Destination).SetInheritanceValidator(v => {
                v.Add(new UserValidator());
            });
        } 
    }
}
