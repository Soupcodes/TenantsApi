using Microsoft.EntityFrameworkCore;

namespace TenantsApi.Models
{
    public class TenantContext : DbContext
    {
        public TenantContext(DbContextOptions<TenantContext> options) : base(options)
        {
        }

        public DbSet<Tenant> TenantDetails { get; set; }
    }
}