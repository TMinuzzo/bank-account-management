using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount.Domain.Entities
{
    public class Payment : TransactionBase
    {
        public override TransactionType Type { get; set; } = TransactionType.PAYMENT;

        public User Source { get; set; }

        public User Destination { get; set; }

        public string Description { get; set; }

    }
}
