﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAccount.API.Models
{
    public class MakeDepositModel
    {
        public int Destination { get; set; }

        public decimal Amount { get; set; }
    }
}
