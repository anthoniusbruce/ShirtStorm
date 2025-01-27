using Microsoft.EntityFrameworkCore;
using ShirtStormCommon.Models;

namespace ShirtStorm.Shared
{
    public class ShirtStormDbContext : DbContext
    {
        public ShirtStormDbContext(DbContextOptions<ShirtStormDbContext> options) : base(options) 
        {
        }

        public DbSet<Design> Designs { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}
