using System.ComponentModel.DataAnnotations;
using FinanceApp.Data.Types;

namespace FinanceApp.Models.Entities
{
    public class BudgetForm
    {
        [Required(ErrorMessage = "Date is a required field")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Amount is a required field")]
        public required decimal Amount { get; set; }
    }
}