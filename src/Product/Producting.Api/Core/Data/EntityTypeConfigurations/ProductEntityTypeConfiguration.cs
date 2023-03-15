using App.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Producting.Api.Core.Data.EntityTypeConfiguration;

public class ProductEntityTyeConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        throw new NotImplementedException();
    }
}