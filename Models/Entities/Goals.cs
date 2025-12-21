using FinanceApp.Models.Enums;

namespace FinanceApp.Models.Entities
{
    public class Goals
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public int TargetAmount { get; set; }
        public DateTime Deadline { get; set; }
        public Priority PriorityLevel { get; set; }
    }
}