using App.Shared.Entities;
using App.Shared.RetryPolicy;
using Microsoft.EntityFrameworkCore;

namespace App.Ordering.Api.Core.Data.MemoryContextSeed;

public class OrderingMemoryContextSeed
{
    private const int RetryNumber = 3;
    private const int SleepDurationInMilliseconds = 5000;
    public async Task SeedAsync(OrderingDbContext dbContext, OrderingMemoryContext memoryContext, IServiceProvider services)
    {
        var retryPplicyFactory = services.GetRequiredService<IRetryPolicyFactory>();
        var logger = services.GetRequiredService<ILogger<OrderingMemoryContextSeed>>();
        var asyncRetryPolicy = retryPplicyFactory.CreateWaitAsyncRetryPolicy<Exception>(RetryNumber, SleepDurationInMilliseconds, nameof(OrderingMemoryContextSeed));
        await asyncRetryPolicy.ExecuteAsync(async () =>
        {
            logger.LogInformation($"Start init memory data of OrderingMemoryContext at: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff zzz")}.");
            var listOrder = await dbContext.Orders.ToListAsync();
            memoryContext.Orders.Clear();
            if (listOrder.Count() > 0)
            {
                foreach (var order in listOrder)
                {
                    if (!memoryContext.Orders.TryGetValue(order.OrderCode, out Order order1))
                        memoryContext.Orders.Add(order.OrderCode, order);
                }
            }
            var listOrderDetail = await dbContext.OrderDetails.ToListAsync();
            memoryContext.OrderDetails.Clear();
            if (listOrderDetail.Count > 0)
            {
                foreach (var orderDetail in listOrderDetail)
                {
                    if (!memoryContext.OrderDetails.TryGetValue(orderDetail.OrderDetailCode, out OrderDetail orderDetail1))
                        memoryContext.OrderDetails.Add(orderDetail.OrderDetailCode, orderDetail);
                }
            }
        });
    }
}