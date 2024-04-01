using Microsoft.EntityFrameworkCore;
using MiniProjekt_API.Models;

namespace MiniProjekt_API.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<Person> Person { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<Interest> Interests { get; set; }

        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Link>()
                .HasKey(l => l.Id);

            modelBuilder.Entity<Interest>()
                .HasKey(i => i.Id);
        }
    }
}
