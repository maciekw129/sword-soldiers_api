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
        
        public DbSet<Game> Games { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameMap>()
                .Property(e => e.Data)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                    v => JsonSerializer.Deserialize<object>(v, (JsonSerializerOptions)null));

            modelBuilder.Entity<GameMap>()
                .HasMany(e => e.Games)
                .WithOne(e => e.Map)
                .HasForeignKey(e => e.MapId);
            
            modelBuilder.Entity<Game>()
                .HasOne(e => e.Map)
                .WithMany(e => e.Games)
                .HasForeignKey(e => e.MapId);
        }
        
    }
}
