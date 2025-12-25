namespace FinanceApp.Models.Entities
{
    public class TransactionIndexViewModel
    {
        public required List<Transaction> Transactions { get; set; }
        public required List<Budget> Budgets { get; set; }
    }
}

