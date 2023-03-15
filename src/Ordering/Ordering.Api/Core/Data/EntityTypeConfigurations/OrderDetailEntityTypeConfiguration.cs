using App.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Ordering.Api.Core.Data.EntityTypeConfigurations;

public class OrderDetailEntityTypeConfiguration : IEntityTypeConfiguration<OrderDetail>
{
    public void Configure(EntityTypeBuilder<OrderDetail> builder)
    {
        builder.ToTable("OrderDetail");
        builder.HasKey(e => e.OrderDetailCode);

        builder.Property(e => e.OrderDetailCode)
        .HasMaxLength(7)
        .IsUnicode(false)
        .HasColumnName("OrderDetailCode");

        builder.Property(e => e.ProductCode)
        .HasMaxLength(7)
        .HasColumnName("ProductCode");

        builder.Property(e => e.ProductName)
        .HasMaxLength(100)
        .HasColumnName("ProductName");

        builder.Property(e => e.Unit)
         .HasColumnName("Unit");

        builder.Property(e => e.RetailPrice)
        .HasColumnName("RetailPrice");

        builder.Property(e => e.NumberProduct)
        .HasColumnName("NumberProduct");

        builder.Property(e => e.TotalPrice)
        .HasColumnName("TotalPrice");

        builder.Property(e => e.Sale)
        .HasColumnName("Sale");

    }
}