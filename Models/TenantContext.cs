using Microsoft.EntityFrameworkCore;

namespace TenantsApi.Models
{
    public class TenantContext : DbContext
    {
        public TenantContext(DbContextOptions<TenantContext> options) : base(options)
        {
        }

        public DbSet<Tenant> TenantDetails { get; set; }
        public DbSet<Landlord> LandlordDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tenant>().ToTable("TenantDetails");
            modelBuilder.Entity<Landlord>().ToTable("LandlordDetails");
            modelBuilder.Entity<Maintenance>().ToTable("MaintenanceDetails");
        }
    }
}