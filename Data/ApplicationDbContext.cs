using Microsoft.EntityFrameworkCore;
using FinanceApp.Models.Entities;

namespace FinanceApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public required DbSet<Subscription> Subscriptions { get; set; }
    }
}
