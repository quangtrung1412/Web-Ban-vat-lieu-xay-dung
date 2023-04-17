using CreateDb.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CreateDb.Data.EntityTypeConfiguration;

public class ProductEntityTyeConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Product");
        builder.HasKey(e => e.ProductCode);

        builder.Property(e => e.ProductCode)
        .HasMaxLength(10)
        .IsUnicode(false)
        .HasColumnName("ProductCode");

        builder.Property(e => e.ProductName)
        .HasMaxLength(10)
        .HasColumnName("ProductName");

        builder.Property(e => e.Image)
       .HasMaxLength(10)
       .HasColumnName("Image");

        builder.Property(e => e.Cost)
        .HasColumnType("NUMBER(20,3)")
        .HasColumnName("Cost");

        builder.Property(e => e.RetailPrice)
        .HasColumnName("RetailPrice");

        builder.Property(e => e.Inventory)
        .HasColumnName("Inventory");

        builder.Property(e => e.Unit)
        .HasConversion<int>()
        .HasColumnName("Unit");

        builder.Property(e => e.Status)
        .HasColumnName("Status");

        builder.Property(e => e.CategoryName)
       .HasMaxLength(100)
       .HasColumnName("CategoryName");

        builder.Property(e => e.TradeMarkName)
       .HasMaxLength(100)
       .HasColumnName("TradeMarkName");
    }
}