using System.ComponentModel.DataAnnotations;
using FinanceApp.Models.Enums;

namespace FinanceApp.Models.Entities
{
    public class GoalsEditForm
    {
        public Guid Id { get; set; }
        public required GoalsForm GoalsForm { get; set; }
    }
}