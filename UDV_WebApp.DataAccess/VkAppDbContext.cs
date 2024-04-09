using Microsoft.EntityFrameworkCore;
using UDV_WebApp.DataAccess.Entities;

namespace UDV_WebApp.DataAccess
{
    public class VkAppDbContext : DbContext
    {
        public VkAppDbContext(DbContextOptions<VkAppDbContext> options)
            : base(options)
        {
        }

        public DbSet<CountResultEntity> CountResultEntities { get; set; }
    }
}
