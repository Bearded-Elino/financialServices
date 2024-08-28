using System.ComponentModel.DataAnnotations;

namespace FinancialServices.models.Enum
{
    public enum TransactionType
    {
        [Display(Name = "Debit")]
        DEBIT,
        [Display(Name = "Credit")]
        CREDIT
    }
}