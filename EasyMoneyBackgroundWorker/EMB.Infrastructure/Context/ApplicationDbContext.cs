using EMB.Domain.Domain;
using EMB.Domain.OrderDomain;
using Microsoft.EntityFrameworkCore;

namespace EMB.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
      
        public DbSet<Order> Orders { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().ToTable("Orders");
            modelBuilder.Entity<Stock>().ToTable("Stocks");
            modelBuilder.Entity<Account>().ToTable("Account");
        }
    }
}
