using FPTS.AccountBalance.Securities.Shared.Data;
using Microsoft.EntityFrameworkCore;

namespace FPTS.AccountBalance.Securities.Shared.Factories;

public class TradingSecuritiesDbContextFactory : IDbContextFactory<TradingSecuritiesDbContext>
{
    private readonly DbContextOptions<TradingSecuritiesDbContext> _options;
    private readonly Func<DbContextOptions<TradingSecuritiesDbContext>, TradingSecuritiesDbContext> _factory;

    public TradingSecuritiesDbContextFactory(DbContextOptions<TradingSecuritiesDbContext> options, Func<DbContextOptions<TradingSecuritiesDbContext>, TradingSecuritiesDbContext> factory)
    {
        _options = options;
        _factory = factory;
    }
    public TradingSecuritiesDbContext CreateDbContext()
    => _factory(_options);

}