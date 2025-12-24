using FinanceApp.Data.Types;
using FinanceApp.Models.Enums;

namespace FinanceApp.Models.Entities
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public required string Name { get; set; }
        public TransactionCategory Category { get; set; }
        public required Currency Amount { get; set; }
    }
}
