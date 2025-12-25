using Microsoft.EntityFrameworkCore;
using FinanceApp.Models.Entities;

namespace FinanceApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>()
                .OwnsOne(t => t.Amount, navigationBuilder =>
                {
                    navigationBuilder.Property(t => t.Amount)
                        .HasColumnName("Amount")
                        .HasColumnType("decimal(18, 2)");
                });
            modelBuilder.Entity<Goals>()
                .OwnsOne(t => t.TargetAmount, navigationBuilder =>
                {
                    navigationBuilder.Property(t => t.Amount)
                        .HasColumnName("Amount")
                        .HasColumnType("decimal(18, 2)");
                });
            modelBuilder.Entity<Subscription>()
                .OwnsOne(t => t.Amount, navigationBuilder =>
                {
                    navigationBuilder.Property(t => t.Amount)
                        .HasColumnName("Amount")
                        .HasColumnType("decimal(18, 2)");
                });
            modelBuilder.Entity<Budget>().HasKey(b => b.Date);
            modelBuilder.Entity<Budget>()
                .Property(b => b.Date)
                .HasColumnType("date");
            modelBuilder.Entity<Budget>()
                .OwnsOne(b => b.Amount, navigationBuilder =>
                {
                    navigationBuilder.Property(t => t.Amount)
                        .HasColumnName("Amount")
                        .HasColumnType("decimal(18, 2)");
                });
            base.OnModelCreating(modelBuilder);
        }

        public required DbSet<Transaction> Transactions { get; set; }
        public required DbSet<Subscription> Subscriptions { get; set; }
        public required DbSet<Goals> Goals { get; set; }
        public required DbSet<Budget> Budgets { get; set; }
    }
}
