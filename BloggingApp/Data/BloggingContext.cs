using Microsoft.EntityFrameworkCore;
using BloggingApp.Models;

namespace BloggingApp.Data
{
    public class BloggingContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

           protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbpath = "Server=localhost; Port=5432; Database=BloggingAppDb; User Id=postgres; Password=fasika; Include Error Detail=true";
            optionsBuilder.UseNpgsql(dbpath);
        }
    }
}