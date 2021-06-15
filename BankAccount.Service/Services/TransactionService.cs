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
            User user = Validate(_userRepository.Select(destination));

            var deposit = new Deposit(amount, user, DateTime.Now);

            return deposit;

        }

        public Withdraw MakeWithdraw(int source, decimal amount)
        {
            User user = Validate(_userRepository.Select(source));

            var withdraw = new Withdraw(amount, user, DateTime.Now);

            return withdraw;

        }

        public Payment MakePayment(int source, string destination, decimal amount, string description)
        {
            User user = Validate(_userRepository.Select(source));

            var payment = new Payment(amount, user, destination, description, DateTime.Now);

            return payment;

        }

        private TInputModel Validate<TInputModel>(TInputModel obj) where TInputModel : class
        {
            if (obj == null)
                throw new Exception("Registro não existente.");

            return obj;
        }
    }
}
