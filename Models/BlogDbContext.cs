using Microsoft.EntityFrameworkCore;

namespace bloginterior.Models
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<BlogPost> BlogPost { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Comment> Comment { get; set; }
    }
}
