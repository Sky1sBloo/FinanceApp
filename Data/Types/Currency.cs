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
            if (Amount > 1000)
            {
                return "Php " + (Amount / 1000).ToString("0.##") + "k";
            } else if (Amount > 1000000)
            {
                return "Php " + (Amount / 1000000).ToString("0.##") + "M";
            }
            return "Php " + Amount.ToString();
        }

        public static string Format(decimal amount)
        {
            if (amount > 1000)
            {
                return "Php " + (amount / 1000).ToString("0.##") + "k";
            } else if (amount > 1000000)
            {
                return "Php " + (amount / 1000000).ToString("0.##") + "M";
            }
            return "Php " + amount.ToString();
        }
    }
}