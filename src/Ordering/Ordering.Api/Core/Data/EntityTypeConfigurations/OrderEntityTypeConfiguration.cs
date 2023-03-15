using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Ordering.Api.Core.Data.EntityTypeConfigurations;

public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Order");
        builder.HasKey(x => x.OrderCode);
        builder.Property(e => e.OrderCode)
        .HasMaxLength(7)
        .IsUnicode(false)
        .HasColumnName("OrderCode");

        builder.Property(e => e.OrderDate)
        .HasPrecision(7)
        .HasColumnName("OrderDate");

        builder.Property(e => e.DeliveryDate)
        .HasPrecision(7)
        .HasColumnName("DeliveryDate");

        builder.Property(e => e.TotalPrice)
        .HasColumnName("TotalPrice");

        builder.Property(e => e.Email)
        .HasMaxLength(100)
        .HasColumnName("Email");

        builder.Property(e => e.Phone)
        .HasMaxLength(10)
        .HasColumnType("number")
        .HasColumnName("Phone");

        builder.Property(e => e.Address)
        .HasColumnType("nvarchar")
        .HasMaxLength(100)
        .HasColumnName("Address");

        builder.Property(e => e.Seller)
        .HasColumnType("nvarchar")
        .HasMaxLength(50)
        .HasColumnName("Seller");

        builder.Property(e => e.Paid)
        .HasColumnName("Paid");

        builder.Property(e => e.Sale)
        .HasColumnName("Sale");

        builder.Property(e => e.Status)
        .HasColumnName("Seller");
        
        var navigation = builder.Metadata.FindNavigation(nameof(OrderDetail.OrderDetailCode));
        navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}