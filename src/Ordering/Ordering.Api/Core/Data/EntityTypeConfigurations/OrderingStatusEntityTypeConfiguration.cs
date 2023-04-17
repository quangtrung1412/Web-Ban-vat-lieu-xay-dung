using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Ordering.Api.Core.Data.EntityTypeConfigurations;

public class  OrderingStatusEntityTypeConfiguration : IEntityTypeConfiguration<OrderingStatus>
{
    public void Configure(EntityTypeBuilder<OrderingStatus> builder)
    {
        builder.ToTable("OrderingStatus");
        builder.HasKey(e => e.Id)
        .HasName("OrderingStatus_pk");

        builder.Property(e => e.Id)
        .HasColumnName("Id")
        .ValueGeneratedNever();

        builder.Property(e => e.Name)
        .HasColumnName("Name")
        .HasMaxLength(100)
        .IsRequired();
    }
}