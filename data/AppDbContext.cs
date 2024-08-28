using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using FinancialServices.models.accountModel;
using FinancialServices.models.customerModel;
using FinancialServices.models.transactionModel;
using Microsoft.EntityFrameworkCore;

namespace FinancialServices.data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<Customer> Customers { get; set;}
        public DbSet<Account> Accounts {get; set;}
        public DbSet<Transactions> Transactions { get; set;}
    }
}