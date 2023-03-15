using App.Producting.Api.Core.Data.Entities;
using App.Producting.Api.Core.Data.EntityTypeConfiguration;
using App.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Producting.Api.Core.Data;

public class ProductDbContext : DbContext
{
    public ProductDbContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<Product> Products {get;set;}
    public DbSet<Category> Categories {get;set;}
    public DbSet<TradeMark> TradeMarks {get;set;}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductEntityTyeConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new TradeMarkEntityTypeConfiguration());
    }
}