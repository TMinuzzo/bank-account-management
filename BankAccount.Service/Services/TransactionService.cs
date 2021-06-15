using AutoMapper;
using BankAccount.Domain.Entities;
using BankAccount.Domain.Interfaces;
using System;

namespace BankAccount.Service.Services
{
    public class TransactionService
    {
        private readonly IBaseRepository<User> _userRepository;

        private readonly IMapper _mapper;


        public TransactionService(IBaseRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Deposit MakeDeposit(int destination, decimal amount)
        {
            // TODO: create validation when there is no user found on db;
            var user = _userRepository.Select(destination);
            var deposit = new Deposit(amount, user, DateTime.Now);

            return deposit;

        }
    }
}
