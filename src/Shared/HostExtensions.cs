using App.Shared.RetryPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace App.Shared;

public static class HostExtensions
{
    public static IHost MigrateMemoryContext<TDbContext, TMemoryContext>(this IHost host, Action<TDbContext, TMemoryContext, IServiceProvider> seeder) where
    TDbContext : DbContext
    {
        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            using (var dbContext = services.GetService<TDbContext>())
            {
                var memoryContext = services.GetService<TMemoryContext>();
                var logger = services.GetRequiredService<ILogger<TDbContext>>();
                var retryPolicyFactory = services.GetRequiredService<IRetryPolicyFactory>();
                try
                {
                    seeder(dbContext, memoryContext, services);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred while migrating the database used on context {DbContextName}", typeof(TDbContext).Name);
                    throw;
                }
            }
        }
        return host;
    }
}