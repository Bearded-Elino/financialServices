using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancialServices.dtos.accountDto;

namespace FinancialServices.interfaces.IAccountRepo
{
    public interface IAccountRepository
    {
        public string GenerateAccountNumberAsync();
        public Task<List<AccountDto>> GetAllAccountsAsync();
        public Task<AccountDto> GetAccountByAccountNumberAsync(string accountNumber);
        public Task<AccountDto> CreateAccountAsync(Guid customerId);
        public Task<AccountDto> GetBalanceAsync(string AccountNumber);

    }
}