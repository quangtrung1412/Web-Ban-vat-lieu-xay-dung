using App.Ordering.OrderingApi.Application.Repositories;
using App.Ordering.OrderingApi.Core.Data.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace App.Ordering.OrderingApi.Core.Data;

public class OrderingDbContext : DbContext
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public OrderingDbContext(DbContextOptions options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new OrderEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new OrderDetailEntityTypeConfiguration());
    }
}