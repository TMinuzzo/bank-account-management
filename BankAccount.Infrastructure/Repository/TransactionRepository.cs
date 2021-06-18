using BankAccount.Domain.DTOs;
using BankAccount.Domain.Entities;
using BankAccount.Infrastructure.Context;
using System;
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

        public List<TransactionBase> GetTransactions(User user)
        {
            var transactionDepositDto = _mySqlContext.Deposits.Where(s => s.Destination == user)
                                                                    .Select(s => new TransactionBase()
                                                                    {
                                                                        Type = s.Type,
                                                                        Amount = s.Amount,
                                                                        Timestamp = s.Timestamp
                                                                    }).ToList();

            var transactionPaymentDto = _mySqlContext.Payments.Where(s => s.Source == user)
                                                        .Select(s => new TransactionBase()
                                                        {
                                                            Type = s.Type,
                                                            Amount = s.Amount,
                                                            Timestamp = s.Timestamp
                                                        }).ToList();

            var transactionWithdrawDto = _mySqlContext.Withdrawals.Where(s => s.Source == user)
                                            .Select(s => new TransactionBase()
                                            {
                                                Type = s.Type,
                                                Amount = s.Amount,
                                                Timestamp = s.Timestamp
                                            }).ToList();

            IEnumerable<TransactionBase> totalTransactions = transactionDepositDto.Concat(transactionPaymentDto).Concat(transactionWithdrawDto);

            return totalTransactions.ToList();
        }
    }
}
