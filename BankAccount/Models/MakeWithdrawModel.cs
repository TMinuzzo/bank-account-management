﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAccount.API.Models
{
    public class MakeWithdrawModel
    {
        public string Source { get; set; }

        public decimal Amount { get; set; }
    }
}
