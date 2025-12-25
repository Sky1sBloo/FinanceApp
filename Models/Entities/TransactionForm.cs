using System.ComponentModel.DataAnnotations;
using FinanceApp.Models.Enums;

namespace FinanceApp.Models.Entities
{
    public class TransactionForm
    {
        [Required(ErrorMessage = "Date is a required field")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Name is a required field")]
        public required string Name { get; set; }
        public TransactionCategory Category { get; set; }

        [Required(ErrorMessage = "Amount is a required field")]
        public decimal Amount { get; set; }
    }
}

