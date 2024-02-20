using Microsoft.EntityFrameworkCore;
using NZWalksStudy.API.Models.Domain;

namespace NZWalksStudy.API.Data
{
    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Difficulty> Difficulties { get; set; }

        public DbSet<Region>Regions { get; set; }

        public DbSet<Walk> Walks { get; set; }
    }
}
