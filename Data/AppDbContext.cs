using Microsoft.EntityFrameworkCore;
using PlantTracker3NET.Models;

namespace PlantTracker3NET.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Plant> Plants { get; set; }

        public DbSet<PlantCareLog> PlantCareLogs { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<PlantNote> PlantNotes { get; set; }

        public DbSet<GardenTool> GardenTools { get; set; }
    }
}