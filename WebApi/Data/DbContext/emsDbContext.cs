using Microsoft.EntityFrameworkCore;
using WebApi.Data.Entities;

namespace WebApi.Data
{
    public class emsDbContext : DbContext
    {
        public emsDbContext(DbContextOptions<emsDbContext> options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Transfer> Transfers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Expense>()
            .Property(e=>e.ExpenseStatus)
            .HasDefaultValue("Pending Approval");
            base.OnModelCreating(modelBuilder);
        }
        

        
    }
}