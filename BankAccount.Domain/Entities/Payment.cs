using System;


namespace BankAccount.Domain.Entities
{
    public class Payment : TransactionBase
    {
        public override TransactionType Type { get; set; } = TransactionType.PAYMENT;

        public User Source { get; set; }

        public string Destination { get; set; }

        public string Description { get; set; }

        public Payment() { }

        public Payment(decimal amount, User source, string destination, string description, DateTime timestamp)
        {
            Amount = amount;
            Source = source;
            Destination = destination;
            Description = description;
            Timestamp = timestamp;
        }

    }
}
