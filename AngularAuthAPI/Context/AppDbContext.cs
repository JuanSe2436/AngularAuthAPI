using AngularAuthAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AngularAuthAPI.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<Reviews> Reviews { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<Books>().ToTable("books");
            modelBuilder.Entity<Reviews>().ToTable("reviews");
        }

    }
}
