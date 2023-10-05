using Microsoft.EntityFrameworkCore;
using blogging_app_webapi.Models;

namespace blogging_app_webapi.Data
{
    public class BloggingContext : DbContext
    {
    public BloggingContext(DbContextOptions<BloggingContext> options) : base(options)
    {

    }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

    
    }
}