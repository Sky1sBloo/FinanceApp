using System.ComponentModel.DataAnnotations;
using FinanceApp.Models.Enums;

namespace FinanceApp.Models.Entities
{
    public class GoalsForm
    {
        [Required(ErrorMessage = "Name is a required field")]
        public required string Name { get; set; }
        public int TargetAmount { get; set; }
        [Required(ErrorMessage = "Deadline is a required field")]
        public DateTime Deadline { get; set; }
        [Required(ErrorMessage = "Priority is a required field")]
        public Priority PriorityLevel { get; set; }
    }
}