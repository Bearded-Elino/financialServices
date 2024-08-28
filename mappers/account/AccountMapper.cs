using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancialServices.dtos.accountDto;
using FinancialServices.dtos.balanceDto;
using FinancialServices.models.accountModel;

namespace FinancialServices.mappers.account
{
    public static class AccountMapper
    {
        public static AccountDto FromAccountModel(this Account account)
        {
            return new AccountDto
            {
                Id = account.Id,
                CustomerId = account.CustomerId,
                AccountBalance = account.AccountBalance,
                CreatedOn = account.CreatedOn,
            };
        }

        public static BalanceDto ToBalanceModel(this Account account)
        {
            return new BalanceDto
            {
                AccountNumber = account.AccountNumber,
                AccountBalance = account.AccountBalance,
            };
        }
    }
}