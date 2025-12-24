using FinanceApp.Data.Types;
using FinanceApp.Models.Enums;

namespace FinanceApp.Models.Entities
{
    public class Subscription
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public TransactionCategory Category { get; set; }
        public required Currency Amount { get; set; }
        public FrequencyType Frequency { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
