using System.ComponentModel.DataAnnotations;
using FinanceApp.Models.Enums;

namespace FinanceApp.Models.Entities
{
    public class TransactionEditForm
    {
        public Guid Id { get; set; }
        public required TransactionForm TransactionForm { get; set; }
    }
}


