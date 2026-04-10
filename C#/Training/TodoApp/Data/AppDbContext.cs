using System.Net;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Models;
namespace ToDoApp.Data;

public class AppDbContext : DbContext
{
    public AppDbContext (DbContextOptions<AppDbContext> options) :base(options) { }

    public DbSet<Todo> Todos { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Todo>()
                .ToTable("Todos")
                .HasKey( t => t.Id);
        
        modelBuilder.Entity<User>()
            .ToTable("Users")
            .HasKey( u => u.Id);
 

        modelBuilder.Entity<Role>()
            .ToTable("Roles")
            .HasKey( r => r.Id);

        modelBuilder.Entity<User>()
                   .HasMany( u => u.Roles)
                   .WithOne( )
                   .HasForeignKey( r => r.UserId);

  
    }
}