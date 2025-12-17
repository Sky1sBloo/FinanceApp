namespace FinanceApp.Models.Entities
{
    public class Transaction
    {
        public DateTime Date { get; set; }
        public required string Name { get; set; }
        public TransactionCategory Category { get; set; }
    }
}
