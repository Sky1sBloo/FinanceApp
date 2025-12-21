using FinanceApp.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace FinanceApp.Models.Entities
{
    public class SubscriptionEditForm
    {
        public Guid Id { get; set; }
        public required SubscriptionForm SubscriptionForm {get; set; }
    }
}