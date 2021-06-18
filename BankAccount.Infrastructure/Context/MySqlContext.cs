using BankAccount.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankAccount.Infrastructure.Context
{
    // Class responsible for the connection with the MySQL database and mapping the tables into entities
    public class MySqlContext : DbContext
    {
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        {

        }
        
        // Using automatic mapping from the Entities to the database provided by EF. 
        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Deposit> Deposits { get; set; }

        public virtual DbSet<Withdraw> Withdrawals { get; set; }

        public virtual DbSet<Payment> Payments { get; set; }

    }
}
