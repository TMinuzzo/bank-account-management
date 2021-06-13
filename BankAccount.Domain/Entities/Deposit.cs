﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount.Domain.Entities
{
    public class Deposit : TransactionBase
    {
        public override TransactionType Type { get; set; } = TransactionType.DEPOSIT;

        public User Destination { get; set; }

    }
}