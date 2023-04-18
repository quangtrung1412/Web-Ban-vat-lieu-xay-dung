using System.Collections.Specialized;
using App.Ordering.Api.Core.Data;
using App.Ordering.Api.Core.Repositories;

namespace App.Ordering.Api.Application.Repositories;

public class OrderDetailRepository : IOrderDetailRepository
{
    private readonly OrderingDbContext _dbContext;
    private readonly ILogger<OrderDetailRepository> _logger;

    public OrderDetailRepository(OrderingDbContext dbContext, ILogger<OrderDetailRepository> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }
    public async Task<OrderDetail> Add(OrderDetail entity)
    {
        try
        {
            _dbContext.OrderDetails.Add(entity);
            return await Task.FromResult(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return null;
        }
    }

    public async Task<OrderDetail> Delete(string id)
    {
        var orderDetail = await GetById(id);
        try
        {
            if (orderDetail != null)
            {
                _dbContext.OrderDetails.Remove(orderDetail);
            }
            return orderDetail;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return null;
        }
    }

    public async Task<OrderDetail> GetById(string id)
    {
        var orderDetail = await _dbContext.OrderDetails.FindAsync(id);
        return orderDetail;
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
    public async Task<OrderDetail> UpdateNumberProduct(string orderDetailCode, long numberProduct)
    {
        var orderDetail = await GetById(orderDetailCode);
        try
        {
            if (orderDetail != null)
            {
                orderDetail.NumberProduct = numberProduct;
                orderDetail.Sale = orderDetail.GetTotalSale();
                orderDetail.TotalPrice = orderDetail.GetTotalPrice();
            }
            return orderDetail;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return null;
        }
    }
    public async Task<OrderDetail> UpdateSale(string orderDetailCode, long sale)
    {
        var orderDetail = await GetById(orderDetailCode);
        try
        {
            if (orderDetail != null)
            {
                orderDetail.Sale = sale;
            }
            return orderDetail;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return null;
        }
    }

    public async Task<OrderDetail> UpdateTotalPrice(string orderDetailCode, long totalPrice)
    {
        var orderDetail = await GetById(orderDetailCode);
        try
        {
            if (orderDetail != null)
            {
                orderDetail.TotalPrice = totalPrice;
            }
            return orderDetail;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return null;
        }
    }
    public async Task<List<OrderDetail>> DeleteListOrderDetail(List<OrderDetail> orderDetails)
    {
         List<OrderDetail> orderDetailResult = new List<OrderDetail>();
        try
        {
            if (orderDetails.Count() > 0)
            {
                _dbContext.OrderDetails.RemoveRange(orderDetails);
                orderDetailResult = orderDetails;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
        }
        return await Task.FromResult(orderDetailResult);
    }
}