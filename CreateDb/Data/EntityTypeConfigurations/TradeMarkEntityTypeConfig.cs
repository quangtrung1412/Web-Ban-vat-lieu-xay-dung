using CreateDb.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace CreateDb.Data.EntityTypeConfiguration;

public class TradeMarkEntityTypeConfiguration : IEntityTypeConfiguration<TradeMark>
{
    public void Configure(EntityTypeBuilder<TradeMark> builder)
    {
        builder.ToTable("TradeMark");
        builder.HasKey(c => c.TradeMarkCode);

        builder.Property(e => e.TradeMarkCode)
        .HasMaxLength(10)
        .IsUnicode(false)
        .HasColumnName("TradeMarkCode");

        builder.Property(e => e.TradeMarkName)
        .HasMaxLength(100)
        .HasColumnName("TradeMarkName");
    }
}
