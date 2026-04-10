using System;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using EfCoreDemo.Models;


namespace EfCoreDemo.Data;

public class AppDbContext : DbContext
{
    public AppDbContext( DbContextOptions<AppDbContext> options)
        :base(options) { }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
}