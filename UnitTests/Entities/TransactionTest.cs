using BankAccount.Domain.Entities;
using BankAccount.Domain.Validators;
using BankAccount.Infrastructure.Repository;
using BankAccount.Service.Services;
using FluentValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount.Tests
{
    [TestClass]
    public class TransactionTest
    {
        readonly UserValidator userValidator = Activator.CreateInstance<UserValidator>();
        readonly TransactionValidator transactionValidator = Activator.CreateInstance<TransactionValidator>();

        [TestMethod, TestCategory("Unit")]
        [ExpectedException(typeof(ValidationException), "Insira um valor no seguinte formato: XX.YY")]
        public void InvalidAmountMoreDigits_ThrowsValidationException()
        {
            var transaction = new TransactionBase { Amount = 100.525m, Type = 0, Timestamp = DateTime.Now };
            transactionValidator.ValidateAndThrow(transaction);

        }

        [TestMethod, TestCategory("Unit")]
        [ExpectedException(typeof(ValidationException), "Insira um valor no seguinte formato: XX.YY")]
        public void InvalidAmountZero_ThrowsValidationException()
        {
            var transaction = new TransactionBase { Amount = 0, Type = 0, Timestamp = DateTime.Now };
            transactionValidator.ValidateAndThrow(transaction);
        }

        [TestMethod, TestCategory("Unit")]
        public void ValidAmount_ReturnsCorrectValue()
        {
            decimal expected = 50.25m;
            var transaction = new TransactionBase { Amount = 50.25m, Type = 0, Timestamp = DateTime.Now };
            transactionValidator.ValidateAndThrow(transaction);

            Assert.AreEqual(transaction.Amount, expected);

        }
    }
}