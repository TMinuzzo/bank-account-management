using BankAccount.Domain.Entities;
using System;

namespace BankAccount.Domain.DTOs
{
    // Data transfer object to avoid exposing Transactions Entities
    public class TransactionDto
    {
        public TransactionType Type { get; set; }
        public decimal Amount { get; set; }
        public DateTime Timestamp { get; set; }

    }
}
