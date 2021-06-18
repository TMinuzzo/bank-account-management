using System;
using System.Collections.Generic;

namespace BankAccount.Domain.Entities
{
    public class User : BaseEntity 
    {
        public string Name { get; set; }

        public decimal Balance { get; set; }

        public void ChangeBalance(TransactionType type, decimal amount)
        {
            if (type == TransactionType.DEPOSIT)
                Balance = Balance + amount;
            if (type == TransactionType.WITHDRAW)
                Balance = Balance - amount;
            if (type == TransactionType.PAYMENT)
                Balance = Balance - amount;
        }

        // Sort all transactions associated to the user, based on DateTime
        public List<TransactionBase> SortUserTransactions(List<TransactionBase> transactions)
        {
            transactions.Sort((t1, t2) => DateTime.Compare(t1.Timestamp, t2.Timestamp));
            return transactions;
        }
    }
}
