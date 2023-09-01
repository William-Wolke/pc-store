using Microsoft.EntityFrameworkCore;

namespace PcStore.Models
{
    public class PcDbContext : DbContext
    {
        public PcDbContext(DbContextOptions options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        public DbSet<Computer> Computers { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
    }
}
