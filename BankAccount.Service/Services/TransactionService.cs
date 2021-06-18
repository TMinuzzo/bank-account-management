using AutoMapper;
using BankAccount.Domain.DTOs;
using BankAccount.Domain.Entities;
using BankAccount.Domain.Interfaces;
using BankAccount.Domain.Validators;
using BankAccount.Infrastructure.Repository;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;


namespace BankAccount.Service.Services
{
    public class TransactionService
    {
        private readonly UserRepository _userRepository;

        private readonly TransactionRepository _transactionRepository;

        private readonly IMapper _mapper;

        private readonly UserValidator _userValidator;

        private readonly TransactionValidator _transactionValidator;

        public TransactionService(UserRepository userRepository, TransactionRepository transactionRepository, IMapper mapper)
        
        {
            _userRepository = userRepository;
            _transactionRepository = transactionRepository;
            _mapper = mapper;

            _userValidator = Activator.CreateInstance<UserValidator>();
            _transactionValidator = Activator.CreateInstance<TransactionValidator>();
        }

        public Deposit MakeDeposit(int destination, decimal amount)
        {
            User user = Validate(_userRepository.Select(destination));
            user.ChangeBalance(TransactionType.DEPOSIT, amount);
            _userValidator.ValidateAndThrow(user);

            var deposit = new Deposit(amount, user, DateTime.Now);

            _transactionValidator.ValidateAndThrow(deposit);

            _userRepository.Update(user);

            return deposit;        

        }

        public Withdraw MakeWithdraw(int source, decimal amount)
        {
            User user = Validate(_userRepository.Select(source));
            user.ChangeBalance(TransactionType.WITHDRAW, amount);

            _userValidator.ValidateAndThrow(user);

            var withdraw = new Withdraw(amount, user, DateTime.Now);

            _transactionValidator.ValidateAndThrow(withdraw);

            _userRepository.Update(user);

            return withdraw;

        }

        public Payment MakePayment(int source, string destination, decimal amount, string description)
        {
            User user = Validate(_userRepository.Select(source));
            user.ChangeBalance(TransactionType.WITHDRAW, amount);

            _userValidator.ValidateAndThrow(user);

            var payment = new Payment(amount, user, destination, description, DateTime.Now);
            _transactionValidator.ValidateAndThrow(payment);

            _userRepository.Update(user);

            return payment;

        }

        public List<TransactionDto> GetHistory(string username)
        {
            var user = Validate(_userRepository.SelectFromUsername(username));

            var transactionsBase = _transactionRepository.GetTransactions(user);

            var sortedTransactions = user.SortUserTransactions(transactionsBase);

            return  sortedTransactions.Select(x => _mapper.Map<TransactionDto>(x)).ToList();

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
