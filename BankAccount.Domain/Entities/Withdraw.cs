using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount.Domain.Entities
{
    public class Withdraw : TransactionBase
    {
        public override TransactionType Type { get; set; } = TransactionType.WITHDRAW;

        public User Source { get; set; }

    }
}
