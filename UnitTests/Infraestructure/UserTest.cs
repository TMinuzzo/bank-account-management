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
    public class UserTest
    {
        [TestMethod]
        public void CreateUsersSaveWithContext_ReturnsValidCount()
        {
            var options = new DbContextOptionsBuilder<MySqlContext>()
            .UseInMemoryDatabase(databaseName: "bank_account")
            .Options;

            using (var context = new MySqlContext(options))
            {
                context.Users.Add(new Domain.Entities.User { Id = 1, Name = "Bob" });
                context.Users.Add(new Domain.Entities.User { Id = 2, Name = "Alice" });
                context.SaveChanges();
            }

            // New context instance to run the test
            using (var context = new MySqlContext(options))
            {
                BaseRepository<Domain.Entities.User> baseRepository = new BaseRepository<Domain.Entities.User>(context);
                IList<Domain.Entities.User> users = baseRepository.Select();

                Assert.AreEqual(2, users.Count);
            }
        }
    }
}