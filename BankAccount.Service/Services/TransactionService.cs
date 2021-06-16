using AutoMapper;
using BankAccount.Domain.Entities;
using BankAccount.Domain.Interfaces;
using BankAccount.Infrastructure.Repository;
using System;
using System.Collections.Generic;

namespace BankAccount.Service.Services
{
    public class TransactionService
    {
        private readonly IBaseRepository<User> _userBaseRepository;

        private readonly UserRepository _userRepository;

        private readonly TransactionRepository _transactionRepository;

        private readonly IMapper _mapper;


        public TransactionService(IBaseRepository<User> userBaseRepository, UserRepository userRepository,
                                  TransactionRepository transactionRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _userBaseRepository = userBaseRepository;
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        public Deposit MakeDeposit(int destination, decimal amount)
        {
            User user = Validate(_userBaseRepository.Select(destination));

            return new Deposit(amount, user, DateTime.Now);

        }

        public Withdraw MakeWithdraw(int source, decimal amount)
        {
            User user = Validate(_userBaseRepository.Select(source));

            return new Withdraw(amount, user, DateTime.Now);

        }

        public Payment MakePayment(int source, string destination, decimal amount, string description)
        {
            User user = Validate(_userBaseRepository.Select(source));

            return new Payment(amount, user, destination, description, DateTime.Now);

        }

        public List<TransactionDto> GetHistory(string username)
        {
            var user = _userRepository.Select(username);

            return _transactionRepository.Select(user);

            // TODO: implement method to order history


        }

        private TInputModel Validate<TInputModel>(TInputModel obj) where TInputModel : class
        {
            if (obj == null)
                throw new Exception("Registro não existente.");

            return obj;
        }
    }
}
