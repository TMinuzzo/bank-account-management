using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount.Domain.Entities
{
    public class Withdraw : TransactionBase
    {
        public override TransactionType Type { get; set; } = TransactionType.WITHDRAW;

        public User Source { get; set; }

        public Withdraw() { }

        public Withdraw(decimal amount, User source, DateTime timestamp)
        {
            Amount = amount;
            Source = source;
            Timestamp = timestamp;
        }
    }
}
