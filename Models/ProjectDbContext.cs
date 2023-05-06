using Microsoft.EntityFrameworkCore;

namespace Final_Project.Models
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext (DbContextOptions<ProjectDbContext> options)
            : base(options)
            {
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<UserBook>().HasKey(u => new {u.BookId, u.UserId});
            }

            public DbSet<Book> Book {get; set;} = default!;
            public DbSet<User> User {get; set;} = default!;
    }
}