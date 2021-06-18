using System;


namespace BankAccount.Domain.Entities
{
    public class TransactionBase : BaseEntity
    {
        public virtual TransactionType Type { get; set; }

        public virtual decimal Amount { get; set; }

        public virtual DateTime Timestamp { get; set; }

    }
}
