using System.ComponentModel.DataAnnotations;
using FinanceApp.Data.Types;

namespace FinanceApp.Models.Entities
{
    public class Budget
    {
        [Key]
        public DateTime Date { get; set; }
        public required Currency Amount { get; set; }
    }
}