using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using SwordSoldiers.Domain.Entities;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace SwordSoldiers.Infrastructure
{
    public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<GameMap> GameMaps { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameMap>()
                .Property(e => e.Data)
                .HasConversion(
                    v => v == null ? null : JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                    v => (v == null ? null : JsonDocument.Parse(v, default(JsonDocumentOptions)))!
                );
        }
    }
}
