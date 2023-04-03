using App.Producting.Producting.Api.Core.Data;

namespace App.Producting.Api.Core.Data.MemoryContextSeed;

public class ProductMemoryContextSeed
{
    public async Task SeedAsync(ProductDbContext dbContext, ProductMemoryContext memoryContext, IServiceProvider services)
    {
        var  retryPolicyFactory = services.GetRequiredService<IRetryPolicyFactory>();
    }
}