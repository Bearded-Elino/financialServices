using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using FinancialServices.models.customerModel;
using FinancialServices.models.Enum;
using Microsoft.EntityFrameworkCore;

namespace FinancialServices.models.accountModel
{
    [Index("AccountNumber", IsUnique = true)]
    [Index("CustomerId", IsUnique =true)]
    public class Account
    {
        [Key]
        public Guid Id { get; set; }
        public string AccountNumber { get; set; }= string.Empty;
        public decimal AccountBalance { get; set; }
        public TransactionType TransactionType { get; set; }

        public Guid CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer? Customer{ get; set; }

        public DateTime CreatedOn { get; set; }= DateTime.Now;
        public DateTime? LastUpdatedOn { get; set;} = DateTime.Now;
    }
}