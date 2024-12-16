using Microsoft.EntityFrameworkCore;
using SwordSoldiers.Domain.Entities;

namespace SwordSoldiers.Infrastructure
{
    public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
