using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Ordering.OrderingApi.Core.Data.EntityTypeConfigurations;

public class OrderDetailTypeConfiguration : IEntityTypeConfiguration<OrderDetail>
{
    public void Configure(EntityTypeBuilder<OrderDetail> builder)
    {
        throw new NotImplementedException();
    }
}