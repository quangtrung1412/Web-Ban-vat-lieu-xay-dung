using App.Ordering.Api.Core.Data.EntityTypeConfigurations;
using App.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Ordering.Api.Core.Data;

public class OrderingDbContext : DbContext
{
    public DbSet<OrderingStatus> OrderingStatuses { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public OrderingDbContext(DbContextOptions options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new OrderingStatusEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new OrderEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new OrderDetailEntityTypeConfiguration());
    }
}