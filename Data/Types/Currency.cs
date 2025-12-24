namespace FinanceApp.Data.Types
{
    public class Currency
    {
        public decimal Amount { get; set; }
        public Currency(decimal amount)
        {
            Amount = amount;
        }
        public override string ToString()
        {
            return "Php " + Amount.ToString();
        }
    }
}