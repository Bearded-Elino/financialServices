using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialServices.dtos.balanceDto
{
    public class BalanceDto
    {
        public string AccountNumber { get; set; } = string.Empty;
        public decimal AccountBalance { get; set;}= 0;
    }
}