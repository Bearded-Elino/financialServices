using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancialServices.data;
using FinancialServices.dtos.accountDto;
using FinancialServices.dtos.balanceDto;
using FinancialServices.interfaces.IAccountRepo;
using FinancialServices.mappers.account;
using FinancialServices.models.accountModel;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace FinancialServices.repos
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDbContext _context;
        public AccountRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<AccountDto> CreateAccountAsync(Guid customerId)
        {
            try
            {
                int createCount = await _context.Accounts.CountAsync(cc => cc.CustomerId == customerId);
                if(createCount >= 1)
                {
                    throw new Exception("customer exists");
                }

                var account = new Account
                {
                    CustomerId = customerId,
                    AccountNumber = GenerateAccountNumberAsync()
                };
                await _context.Accounts.AddAsync(account);
                await _context.SaveChangesAsync();
                return account.FromAccountModel();                
            }
            catch (System.Exception)
            {
                
                throw new Exception("can't perform operation");
            }
        }

        public string GenerateAccountNumberAsync()
        {
            try
            {
                Random random = new Random();
                string numbers = "0123456789";
                string accountNumber = "";
                int length = 10;
                for (int i = 0; i < length; i++)
                {
                    accountNumber += numbers[random.Next(numbers.Length)];
                }
                return accountNumber;
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        public async Task<AccountDto> GetAccountByAccountNumberAsync(string accountNumber)
        {
            try
            {
                var account = await _context.Accounts.FirstOrDefaultAsync(x => x.AccountNumber == accountNumber);
                if (account == null)
                {
                    return null;
                }
                return account.FromAccountModel();
            }
            catch (Exception ex)
            {
                
                throw new Exception("cannot display account", ex);
            };
        }

        public async Task<List<AccountDto>> GetAllAccountsAsync()
        {
            try
            {
                var accounts = await _context.Accounts.Select(ac => ac.FromAccountModel()).ToListAsync();
            return accounts;
            }
            catch (Exception ex)
            {
                
                throw new Exception("unable to show accounts", ex);
            }
        }

        public Task<AccountDto> GetBalanceAsync(string AccountNumber)
        {
            throw new NotImplementedException();
        }
    }
}