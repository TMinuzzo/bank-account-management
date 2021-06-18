using System;


namespace BankAccount.Domain.Entities
{
    public class Deposit : TransactionBase
    {
        public override TransactionType Type { get; set; } = TransactionType.DEPOSIT;

        public User Destination { get; set; }

        public Deposit() {}

        public Deposit(decimal amount, User destination, DateTime timestamp)
        {
            Amount = amount;
            Destination = destination;
            Timestamp = timestamp;
        }
    }
}
