using BankAccount.Domain.Entities;
using BankAccount.Infrastructure.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount.Infrastructure.Context
{
    // Class responsible for the connection with the MySQL database and mapping the tables into entities
    public class MySqlContext : DbContext
    {
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }

        public DbSet<Deposit> Deposits { get; set; }

        public DbSet<Withdraw> Withdrawals { get; set; }

        public DbSet<Payment> Payments { get; set; }

        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<User>(new UserMap().Configure);
            //modelBuilder.Entity<Deposit>(new DepositMap().Configure);
        }
        */
    }
}
