using App.Producting.Api.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Producting.Api.Core.Data.EntityTypeConfiguration;

public class TradeMarkEntityTypeConfiguration : IEntityTypeConfiguration<TradeMark>
{
    public void Configure(EntityTypeBuilder<TradeMark> builder)
    {
        throw new NotImplementedException();
    }
}
