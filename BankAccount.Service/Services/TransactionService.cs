using AutoMapper;
using BankAccount.Domain.DTOs;
using BankAccount.Domain.Entities;
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

        private readonly UserValidator _userValidator;

        private readonly TransactionValidator _transactionValidator;

        private readonly IMapper _mapper;

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
            // Validate new user balance
            var user = Validate(_userRepository.Select(destination));
            user.ChangeBalance(TransactionType.DEPOSIT, amount);
            _userValidator.ValidateAndThrow(user);

            // Validate new deposit
            var deposit = new Deposit(amount, user, DateTime.Now);
            _transactionValidator.ValidateAndThrow(deposit);

            // Update user balance
            _userRepository.Update(user);

            return deposit;        

        }

        public Withdraw MakeWithdraw(int source, decimal amount)
        {
            // Validate new user balance
            var user = Validate(_userRepository.Select(source));
            user.ChangeBalance(TransactionType.WITHDRAW, amount);
            _userValidator.ValidateAndThrow(user);

            // Validate new withdraw
            var withdraw = new Withdraw(amount, user, DateTime.Now);
            _transactionValidator.ValidateAndThrow(withdraw);

            // Update user balance
            _userRepository.Update(user);

            return withdraw;

        }

        public Payment MakePayment(int source, string destination, decimal amount, string description)
        {
            // Validate new user balance
            var user = Validate(_userRepository.Select(source));
            user.ChangeBalance(TransactionType.PAYMENT, amount);
            _userValidator.ValidateAndThrow(user);

            // Validate new payment
            var payment = new Payment(amount, user, destination, description, DateTime.Now);
            _transactionValidator.ValidateAndThrow(payment);

            // Update user balance
            _userRepository.Update(user);

            return payment;

        }

        public List<TransactionDto> GetHistory(string username)
        {
            var user = Validate(_userRepository.SelectFromUsername(username));

            var transactionsBase = _transactionRepository.GetTransactions(user);

            var sorted = user.SortUserTransactions(transactionsBase);

            return sorted.Select(x => _mapper.Map<TransactionDto>(x)).ToList();

        }

        private TInputModel Validate<TInputModel>(TInputModel entity) where TInputModel : class
        {
            if (entity == null)
                throw new Exception("Registro não existente.");

            return entity;
        }
    }
}
