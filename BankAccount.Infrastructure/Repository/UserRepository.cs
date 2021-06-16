using BankAccount.Domain.Entities;
using BankAccount.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankAccount.Infrastructure.Repository
{
    public class UserRepository
    {
        protected readonly MySqlContext _mySqlContext;

        public UserRepository(MySqlContext mySqlContext)
        {
            _mySqlContext = mySqlContext;
        }

        public User Select(string name)
        {
            return _mySqlContext.Users.Where(s => s.Name == name).ToList().First();
        }
    }
}
