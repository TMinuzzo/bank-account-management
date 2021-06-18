using AutoMapper;
using BankAccount.Domain.Entities;
using BankAccount.Infrastructure.Context;
using BankAccount.Infrastructure.Repository;
using BankAccount.Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;


namespace BankAccount.Tests.Infraestructure
{
    [TestClass]
    public class TransactionRepositoryTest
    {
        [TestMethod]
        public void CreateTransactionsSaveWithContext_ReturnsValidCount()
        {
            var options = new DbContextOptionsBuilder<MySqlContext>()
            .UseInMemoryDatabase(databaseName: "bank_account")
            .Options;

            using (var context = new MySqlContext(options))
            {
                User user = new User { Id = 1, Name = "Alice" };
                context.Deposits.Add(new Deposit { Id = 1, Amount = 50.25m, Destination = user, Timestamp = DateTime.Now, Type = TransactionType.DEPOSIT });
                context.Withdrawals.Add(new Withdraw { Id = 1, Amount = 50.25m, Source = user, Timestamp = DateTime.Now, Type = TransactionType.WITHDRAW });
                context.Payments.Add(new Payment { Id = 1, Amount = 50.25m, Source = user, Destination = "Feira", Timestamp = DateTime.Now,  Description = "Pagamento da Feira", Type = TransactionType.PAYMENT });

                context.SaveChanges();
            }

            // New context instance to run the test
            using (var context = new MySqlContext(options))
            {
                BaseRepository<Deposit> baseRepositoryDeposit = new BaseRepository<Deposit>(context);
                BaseRepository<Withdraw> baseRepositoryWithdraw = new BaseRepository<Withdraw>(context);
                BaseRepository<Payment> baseRepositoryPayment = new BaseRepository<Payment>(context);

                IList<Deposit> deposits = baseRepositoryDeposit.Select();
                IList<Withdraw> withdrawals = baseRepositoryWithdraw.Select();
                IList<Payment> payments = baseRepositoryPayment.Select();

                Assert.AreEqual(1, deposits.Count);
                Assert.AreEqual(1, withdrawals.Count);
                Assert.AreEqual(1, payments.Count);
            }
        }
    }
}
