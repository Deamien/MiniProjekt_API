using Microsoft.EntityFrameworkCore;
using MiniProjekt_API.Models;

namespace MiniProjekt_API.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<People> People { get; set; }
        public DbSet<InterestUrls> InterestUrls { get; set; }
        public DbSet<Interests> Interests { get; set; }

        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<People>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<InterestUrls>()
                .HasKey(l => l.Id);

            modelBuilder.Entity<Interests>()
                .HasKey(i => i.Id);
        }
    }
}
