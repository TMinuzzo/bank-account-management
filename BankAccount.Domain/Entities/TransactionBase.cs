using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount.Domain.Entities
{
    public enum TransactionType
    {
        WITHDRAW,
        DEPOSIT,
        PAYMENT,
    }
    public abstract class TransactionBase : BaseEntity
    {
        public virtual TransactionType Type { get; set; }

        public virtual decimal Amount { get; set; }

        public virtual DateTime Timestamp { get; set; }

    }
}
