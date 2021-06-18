using BankAccount.Domain.Entities;
using BankAccount.Domain.Validators;
using FluentValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace UnitTests
{
    [TestClass]
    public class UserTest
    {
        readonly UserValidator userValidator = Activator.CreateInstance<UserValidator>();

        [TestMethod, TestCategory("Unit")]
        [ExpectedException(typeof(ValidationException), "Insira um nome válido")]
        public void InvalidUserData_ThrowsValidationException()
        {
            var user = new User { Name = "", Balance = 0 };

            userValidator.ValidateAndThrow(user);
        }

        [TestMethod, TestCategory("Unit")]
        [ExpectedException(typeof(ValidationException), "Não foi possível realizar a transação: Saldo insuficiente")]
        public void ChangeBalance_ThrowsValidationException()
        {
            var user = new User { Name = "Bob", Balance = 0 };

            user.ChangeBalance(TransactionType.WITHDRAW, 50);

            userValidator.ValidateAndThrow(user);
        }
        [TestMethod, TestCategory("Unit")]
        public void ChangeBalance_ReturnsCorrectValue()
        {
            decimal expected = 0;

            var user = new User { Name = "Bob", Balance = 50 };

            user.ChangeBalance(TransactionType.WITHDRAW, 50);

            userValidator.ValidateAndThrow(user);

            Assert.AreEqual(user.Balance, expected);
        }
    }
}
