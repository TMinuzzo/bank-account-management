using FluentValidation;

namespace BankAccount.Domain.Entities
{
    public class User : BaseEntity 
    {
        public string Name { get; set; }

        public decimal Balance { get; set; }

        public void ChangeBalance(TransactionType type, decimal amount)
        {
            if (type == TransactionType.DEPOSIT)
                Balance = Balance + amount;
            if (type == TransactionType.WITHDRAW)
                Balance = Balance - amount;
            if (type == TransactionType.PAYMENT)
                Balance = Balance - amount;
        }
    }
}
