using App.Shared.Entities;
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
        .HasMaxLength(10)
        .IsUnicode(false)
        .HasColumnName("OrderCode");   

        builder.Property(e => e.OrderDate)
        .HasColumnName("OrderDate");

        builder.Property(e => e.DeliveryDate)
        .HasColumnName("DeliveryDate");

        builder.Property(e => e.TotalPrice)
        .HasColumnName("TotalPrice");

        builder.Property(e => e.Email)
        .HasMaxLength(100)
        .HasColumnName("Email");

        builder.Property(e => e.Phone)
        .HasColumnType("Number")
        .HasMaxLength(10)
        .HasColumnName("Phone");

        builder.Property(e => e.Address)
        .HasMaxLength(100)
        .HasColumnName("Address");

        builder.Property(e => e.Seller)
        .HasMaxLength(50)
        .HasColumnName("Seller");

        builder.Property(e => e.Paid)
        .HasColumnName("Paid");

        builder.Property(e => e.Sale)
        .HasColumnName("Sale");

        builder.Property(e => e.Status)
        .HasConversion(s => s.Id, s => OrderingStatus.From(s))
        .IsRequired(false)
        .HasColumnName("Status");

    }
}