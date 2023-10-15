using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TestTaskShuttleX.Infrastructure.Model;

namespace TestTaskShuttleX.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
        }

        public DbSet<Message> Messages { get; set; } = null!;
        public DbSet<Room> Rooms { get; set; } = null!;
        public DbSet<LiveConnection> LiveConnections { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}
