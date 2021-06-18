using BankAccount.Domain.Entities;
using BankAccount.Infrastructure.Context;
using System.Linq;

namespace BankAccount.Infrastructure.Repository
{
    public class UserRepository : BaseRepository<User>
    {
        protected new readonly MySqlContext _mySqlContext;

        public UserRepository(MySqlContext mySqlContext) : base(mySqlContext)
        {
            _mySqlContext = mySqlContext;
        }

        public User SelectFromUsername(string name)
        {
            return _mySqlContext.Users.Where(s => s.Name == name).ToList().First();
        }
    }
}
