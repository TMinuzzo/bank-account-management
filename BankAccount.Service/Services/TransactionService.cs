using AutoMapper;
using BankAccount.Domain.DTOs;
using BankAccount.Domain.Entities;
using BankAccount.Domain.Interfaces;
using BankAccount.Domain.Validators;
using BankAccount.Infrastructure.Repository;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace BankAccount.Service.Services
{
    public class TransactionService
    {
        //private readonly IBaseRepository<Deposit> _depositBaseRepository;

        private readonly UserRepository _userRepository;

        private readonly TransactionRepository _transactionRepository;

        private readonly IMapper _mapper;

        private readonly UserValidator _userValidator;

        public TransactionService(UserRepository userRepository, TransactionRepository transactionRepository, IMapper mapper)
        
        {
            _userRepository = userRepository;
            _transactionRepository = transactionRepository;
            _mapper = mapper;

            _userValidator = Activator.CreateInstance<UserValidator>();
        }

        public Deposit MakeDeposit(int destination, decimal amount)
        {
            User user = Validate(_userRepository.Select(destination));
            user.ChangeBalance(TransactionType.DEPOSIT, amount);
            _userValidator.ValidateAndThrow(user);

            var deposit = new Deposit(amount, user, DateTime.Now);
            _userRepository.Update(user);

            return deposit;        

        }

        public Withdraw MakeWithdraw(int source, decimal amount)
        {
            User user = Validate(_userRepository.Select(source));
            user.ChangeBalance(TransactionType.WITHDRAW, amount);

            var validator = Activator.CreateInstance<UserValidator>();

            validator.ValidateAndThrow(user);


            _userRepository.Update(user);
            return new Withdraw(amount, user, DateTime.Now);

        }

        public Payment MakePayment(int source, string destination, decimal amount, string description)
        {
            User user = Validate(_userRepository.Select(source));

            _userValidator.ValidateAndThrow(user);

            user.Balance = user.Balance - amount;
            _userRepository.Update(user);
            return new Payment(amount, user, destination, description, DateTime.Now);


        }

        public List<TransactionDto> GetHistory(string username)
        {
            var user = _userRepository.SelectFromUsername(username);

            return _transactionRepository.GetTransactions(user);

            // TODO: implement method to order history

        }

        private TInputModel Validate<TInputModel>(TInputModel obj) where TInputModel : class
        {
            // TODO: Throw a better exception (maybe custom) and handle it
            if (obj == null)
                throw new Exception("Registro não existente.");

            return obj;
        }
    }
}
