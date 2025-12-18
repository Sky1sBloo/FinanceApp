using FinanceApp.Models.Enums;

namespace FinanceApp.Models.Entities
{
    public class SubscriptionForm
    {
        public string? Name { get; set; }
        public TransactionCategory Category { get; set; }
        public int Amount { get; set; }
        public FrequencyType Frequency { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
