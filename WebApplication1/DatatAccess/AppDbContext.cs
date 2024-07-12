using Microsoft.EntityFrameworkCore;
using ProjectPatisserie.Entities;
using System.Reflection;

namespace ProjectPatisserie.DatatAccess
{
    public class AppDbContext : DbContext
    {

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(assembly: Assembly.GetExecutingAssembly());
        }
        public AppDbContext(DbContextOptions dbContextOptions)
       : base(dbContextOptions)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                base.OnConfiguring(
                    optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=ProjectPatisserieDb;User Id=postgres;Password=12345;"));
        }
    }
}
