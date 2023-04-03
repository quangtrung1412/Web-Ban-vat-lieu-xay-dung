using App.Ordering.Api.Core.Data;
using App.Ordering.Api.Core.Repositories;

namespace App.Ordering.Api.Application.Repositories;

public class OrderingRepository : IOrderingRepository

{
    private readonly OrderingDbContext _dbContext;
    private readonly ILogger<OrderingRepository> _logger;

    public OrderingRepository(OrderingDbContext dbContext, ILogger<OrderingRepository> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }
    public async Task<Order> Add(Order entity)
    {
        try
        {
            _dbContext.Orders.Add(entity);
            return await Task.FromResult(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return null;
        }
    }

    public async Task<Order> Delete(string id)
    {
        var order = await GetById(id);
        try
        {
            if (order != null)
            {
                _dbContext.Orders.Remove(order);
            }
            return order;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return null;
        }
    }

    public async Task<Order> GetById(string id)
    {
        var order = await _dbContext.Orders.FindAsync(id);
        return order;
    }

    public void SaveChangesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Order> UpdateDeliveryDate(string orderCode, DateTime deliveryDate)
    {
        throw new NotImplementedException();
    }

    public Task<Order> UpdateOrderDate(string orderCode, DateTime dateTime)
    {
        throw new NotImplementedException();
    }

    public Task<Order> UpdatePaid(string orderCode, long paid)
    {
        throw new NotImplementedException();
    }

    public Task<Order> UpdateSale(string orderCode, long sale)
    {
        throw new NotImplementedException();
    }

    public Task<Order> UpdateStatus(string orderCode, OrderingStatus status)
    {
        throw new NotImplementedException();
    }

    public Task<Order> UpdateTotalPrice(string orderCode, long totalPrice)
    {
        throw new NotImplementedException();
    }
}