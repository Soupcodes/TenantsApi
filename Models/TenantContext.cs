using Microsoft.EntityFrameworkCore;

namespace TenantsApi.Models
{
    public class TenantContext : DbContext
    {
        public TenantContext(DbContextOptions<TenantContext> options) : base(options)
        {
        }

        public DbSet<Tenant> TenantDetails { get; set; }
        public DbSet<Property> PropertyDetails { get; set; }
        public DbSet<Maintenance> MaintenanceDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tenant>().ToTable("TenantDetails");
            modelBuilder.Entity<Property>().ToTable("PropertyDetails");
            modelBuilder.Entity<Maintenance>().ToTable("MaintenanceDetails");
        }
    }
}