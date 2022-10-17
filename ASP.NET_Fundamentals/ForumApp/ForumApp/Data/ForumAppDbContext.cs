using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;
using ForumApp.Data.Entities;

namespace ForumApp.Data;

public class ForumAppDbContext : DbContext
{
    public ForumAppDbContext(DbContextOptions<ForumAppDbContext> options)
        :base(options)
    {
        this.Database.Migrate();
    }
       
    public DbSet<Post> Posts { get; init; }
    
    private Post FirstPost { get; set; }

    private Post SecondPost { get; set; }
    
    private Post ThirdPost { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        SeedPosts();

        builder.Entity<Post>()
            .HasData(this.FirstPost,
                this.SecondPost,
                this.ThirdPost);
        base.OnModelCreating(builder);
    }

    private void SeedPosts()
    {
        FirstPost = new Post()
        {
            Id = 1,
            Title = "My first post",
            Content = "My first post will be about performing."
        };

        SecondPost = new Post()
        {
            Id = 2,
            Title = "My second post",
            Content = "This is my second post."
        };

        ThirdPost = new Post()
        {
            Id = 3,
            Title = "My third post",
            Content = "Hello there! I'm getting better and better with the CRUD operations in MVC. Stay tuned!"
        };
    }
}