using App.Producting.Producting.Api.Core.Data;
using App.Shared.Entities;
using App.Shared.RetryPolicy;
using Microsoft.EntityFrameworkCore;

namespace App.Producting.Api.Core.Data.MemoryContextSeed;

public class ProductMemoryContextSeed
{
    private const int RetryNumber = 3;
    private const int SleepDurationInMilliseconds = 5000;
    public async Task SeedAsync(ProductDbContext dbContext, ProductMemoryContext memoryContext, IServiceProvider services)
    {
        var retryPolicyFactory = services.GetRequiredService<IRetryPolicyFactory>();
        var logger = services.GetRequiredService<ILogger<ProductMemoryContextSeed>>();
        var asyncRetryPolicy = retryPolicyFactory.CreateWaitAsyncRetryPolicy<Exception>(RetryNumber, SleepDurationInMilliseconds, nameof(ProductMemoryContextSeed));
        await asyncRetryPolicy.ExecuteAsync(async () =>
        {
            logger.LogInformation($"Start init memory data of ProductMemoryContextSeed at: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff zzz")}.");
            var listProduct = await dbContext.Products.ToListAsync();
            memoryContext.Products.Clear();
            if (listProduct.Count() > 0)
            {
                foreach (var product in listProduct)
                {
                    if (!memoryContext.Products.TryGetValue(product.ProductCode, out Product product1))
                        memoryContext.Products.Add(product.ProductCode, product);
                }
            }
            var listCategory =await dbContext.Categories.ToListAsync();
            memoryContext.Categories.Clear();
             if (listCategory.Count() > 0)
            {
                foreach (var category in listCategory)
                {
                    if (!memoryContext.Categories.TryGetValue(category.CategoryCode, out Category category1))
                        memoryContext.Categories.Add(category.CategoryCode, category);
                }
            }
            var listTradeMark =await dbContext.TradeMarks.ToListAsync();
            memoryContext.TradeMarks.Clear();
             if (listTradeMark.Count() > 0)
            {
                foreach (var tradeMark in listTradeMark)
                {
                    if (!memoryContext.TradeMarks.TryGetValue(tradeMark.TradeMarkCode, out TradeMark tradeMark1))
                        memoryContext.TradeMarks.Add(tradeMark.TradeMarkCode, tradeMark);
                }
            }
        });
    }
}