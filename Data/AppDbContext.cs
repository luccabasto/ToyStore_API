using Microsoft.EntityFrameworkCore;
using ToyStore_API.Models;

namespace ToyStore_API.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Toys> Toys { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Toys>().ToTable("TB_TOYS");
        }
    }
}
