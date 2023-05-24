
using App.Producting.Api.Core.Data;
using App.Producting.Producting.Api.Core.Data;

namespace App.Shared;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddStorageContext(this IServiceCollection services, string connectionString)
    {
        var memoryContext = new ProductMemoryContext();
        return services.AddOracle<ProductDbContext>(connectionString)
        .AddSingleton<IDbContextFactory<AccountBalanceDbContext>>(sp =>
        {
            var opt = new DbContextOptionsBuilder<AccountBalanceDbContext>()
             .UseOracle(connectionString).Options;
            return new AccountBalanceDbContextFactory(opt, options => new AccountBalanceDbContext(options));
        })
        .AddSingleton(memoryContext);
    }
}