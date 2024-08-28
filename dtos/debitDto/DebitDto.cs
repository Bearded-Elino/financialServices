using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialServices.dtos.debitDto
{
    public class DebitDto
    {
        public string AccountNumber { get; set; }=string.Empty;
        public decimal AccountBalance { get; set; }=0;
    }
}