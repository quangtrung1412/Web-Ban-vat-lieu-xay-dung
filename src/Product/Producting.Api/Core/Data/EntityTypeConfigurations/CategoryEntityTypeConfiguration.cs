using App.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Producting.Api.Core.Data.EntityTypeConfiguration;

public class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Category");
        builder.HasKey(c => c.CategoryCode);

        builder.Property(e => e.CategoryCode)
        .HasMaxLength(10)
        .IsUnicode(false)
        .HasColumnName("CategoryCode");

        builder.Property(e => e.CategoryName)
        .HasMaxLength(100)
        .HasColumnName("CategoryName");

    }
}
