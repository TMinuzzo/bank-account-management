using BankAccount.Domain.Entities;
using BankAccount.Infrastructure.Context;
using System.Collections.Generic;
using System.Linq;

namespace BankAccount.Infrastructure.Repository
{

    public class TransactionRepository : BaseRepository<TransactionBase>
    {
        protected new readonly MySqlContext _mySqlContext;

        public TransactionRepository(MySqlContext mySqlContext) : base(mySqlContext)
        {
            _mySqlContext = mySqlContext;
        }

        // Get user Transactions from Deposits, Payments and Withdrawals, mapping all them to TransactionBase and returning a concateneted list of them.
        public List<TransactionBase> GetTransactions(User user)
        {
            var transactionsDeposit = _mySqlContext.Deposits.Where(s => s.Destination == user).Select(s => new TransactionBase() { Type = s.Type, Amount = s.Amount, Timestamp = s.Timestamp }).ToList();

            var transactionsPayment = _mySqlContext.Payments.Where(s => s.Source == user).Select(s => new TransactionBase() { Type = s.Type, Amount = s.Amount, Timestamp = s.Timestamp }).ToList();

            var transactionsWithdraw = _mySqlContext.Withdrawals.Where(s => s.Source == user).Select(s => new TransactionBase(){Type = s.Type,Amount = s.Amount,Timestamp = s.Timestamp}).ToList();

            IEnumerable<TransactionBase> totalTransactions = transactionsDeposit.Concat(transactionsPayment).Concat(transactionsWithdraw);

            return totalTransactions.ToList();
        }
    }
}
