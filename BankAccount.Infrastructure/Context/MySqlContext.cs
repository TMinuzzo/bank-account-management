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
    }
}
