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
        
    }
}