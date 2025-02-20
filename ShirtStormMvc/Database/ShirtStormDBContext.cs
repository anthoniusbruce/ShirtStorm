using Microsoft.EntityFrameworkCore;
using ShirtStormCommon.Models;

namespace ShirtStormMvc.Database
{
    public class ShirtStormDbContext : DbContext
    {
        public ShirtStormDbContext(DbContextOptions<ShirtStormDbContext> options) : base(options) 
        {
        }

        public DbSet<Design> Designs { get; set; } = default!;
        public DbSet<Image> Images { get; set; } = default!;
        public DbSet<Customer> Customers { get; set; } = default!;
    }
}
