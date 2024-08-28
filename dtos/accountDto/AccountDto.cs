using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialServices.dtos.accountDto
{
    public class AccountDto
    {
        public Guid Id { get; set; }
        public decimal AccountBalance {get; set;}
        public Guid CustomerId { get; set;}
        public string AccountNumber { get; set;} = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}