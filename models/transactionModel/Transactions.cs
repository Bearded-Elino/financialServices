using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using FinancialServices.models.accountModel;
using FinancialServices.models.customerModel;
using FinancialServices.models.Enum;

namespace FinancialServices.models.transactionModel
{
    public class Transactions
    {
        [Key]
        public Guid Id { get; set; }

        public TransactionType TransactionType{ get; set; }
        public Guid AccountId { get; set; }
        [ForeignKey("AccountId")]
        public Account? Account{ get; set; }
        public Guid CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer? Customer{ get; set; }
        public DateTime CreatedDate { get; set;} = DateTime.Now;
        public DateTime UpdatedDate { get; set;} = DateTime.Now;
    }
}