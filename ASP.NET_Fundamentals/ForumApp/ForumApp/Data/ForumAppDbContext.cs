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

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Post>();
        
        base.OnModelCreating(builder);
    }
}