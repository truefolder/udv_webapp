using Microsoft.EntityFrameworkCore;
using UDV_WebApp.Core.Models;
using UDV_WebApp.DataAccess.Configurations;
using UDV_WebApp.DataAccess.Entities;

namespace UDV_WebApp.DataAccess
{
    public class VkAppDbContext : DbContext
    {
        public VkAppDbContext(DbContextOptions<VkAppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<CountResultEntity>(countResult =>
            {
                builder.ApplyConfiguration(new CountResultConfiguration());
            });
        }

        public DbSet<CountResultEntity> CountResultEntities { get; set; }
    }
}
