using App.Ordering.Api.Core.Data;
using App.Ordering.Api.Core.Repositories;
using App.Shared.Entities;

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

    public async void SaveChangesAsync()
    {
        try
        {
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
        }
    }

    public async Task<Order> UpdateDeliveryDate(string orderCode, DateTime deliveryDate)
    {
        var order = await GetById(orderCode);
        try
        {
            if (order != null)
            {
                order.DeliveryDate = deliveryDate;
            }
            return order;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return null;
        }
    }

    public async Task<Order> UpdateOrderDate(string orderCode, DateTime dateTime)
    {
        var order = await GetById(orderCode);
        try
        {
            if (order != null)
            {
                order.OrderDate = dateTime;
            }
            return order;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return null;
        }
    }

    public async Task<Order> UpdatePaid(string orderCode, long paid)
    {
        var order = await GetById(orderCode);
        try
        {
            if (order != null)
            {
                order.Paid = paid;
            }
            return order;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return null;
        }
    }

    public async Task<Order> UpdateSale(string orderCode, long sale)
    {
        var order = await GetById(orderCode);
        try
        {
            if (order != null)
            {
                order.Sale = sale;
            }
            return order;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return null;
        }
    }

    public async Task<Order> UpdateStatus(string orderCode, OrderingStatus status)
    {
         var order = await GetById(orderCode);
        try
        {
            if (order != null)
            {
                order.Status = status;
            }
            return order;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return null;
        }
    }

    public async Task<Order> UpdateTotalPrice(string orderCode, long totalPrice)
    {
         var order = await GetById(orderCode);
        try
        {
            if (order != null)
            {
                order.TotalPrice = totalPrice;
            }
            return order;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return null;
        }
    }
}