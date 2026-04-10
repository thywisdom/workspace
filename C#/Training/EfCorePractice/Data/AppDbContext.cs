using System;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using EfCorePractice.Models;

namespace EfCorePractice.Data;

public class AppDbContext : DbContext
{
    public AppDbContext ( DbContextOptions<AppDbContext> options)
        :base(options) { } 

    public DbSet<Student> Students { get; set;}
    public DbSet<Teacher> Teachers { get; set;} 
    public DbSet<Branch> Branches { get; set;} 
    public DbSet<Course> Courses { get; set;} 
    public DbSet<Subject> Subjects { get; set;} 
    public DbSet<Address> Addresses { get; set;}
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
