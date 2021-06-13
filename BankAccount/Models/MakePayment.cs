using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAccount.API.Models
{
    public class MakePayment
    {
        public string Source { get; set; }
        public string Destination { get; set; }

        public decimal Amount { get; set; }

        public string Description { get; set; }
    }
}
