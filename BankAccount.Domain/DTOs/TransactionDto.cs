using BankAccount.Domain.Entities;
using System;

namespace BankAccount.Domain.DTOs
{
    public class TransactionDto
    {
        public TransactionType Type { get; set; }
        public decimal Amount { get; set; }
        public DateTime Timestamp { get; set; }

    }
}
