namespace FinanceApp.Models.Entities
{
    public class SubscriptionIndexViewModel 
    {
        public required SubscriptionForm Form { get; set; }
        public required List<Subscription> Subscriptions { get; set; }
    }
}
