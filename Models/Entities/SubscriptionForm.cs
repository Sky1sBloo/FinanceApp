using FinanceApp.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace FinanceApp.Models.Entities
{
    public class SubscriptionForm
    {
        [Required(ErrorMessage = "Required field")]
        public required string Name { get; set; }
        public TransactionCategory Category { get; set; }

        [Required(ErrorMessage = "Required field")]
        public int Amount { get; set; }
        public FrequencyType Frequency { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
