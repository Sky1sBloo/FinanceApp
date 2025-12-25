using FinanceApp.Data.Types;
using FinanceApp.Models.Enums;

namespace FinanceApp.Models.Entities
{
    public class Goals
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required Currency TargetAmount { get; set; }
        public DateTime Deadline { get; set; }
        public Priority PriorityLevel { get; set; }
    }
}