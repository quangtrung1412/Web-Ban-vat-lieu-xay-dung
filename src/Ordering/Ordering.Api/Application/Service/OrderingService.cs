using App.Ordering.Api.Core.Data;
using App.Ordering.Api.Core.Repositories;
using App.Ordering.Api.Core.Service;

namespace App.Ordering.Api.Application.Service;

public class OrderingService : IOrderingService
{
    private readonly OrderingMemoryContext _memoryContext;

    public OrderingService(OrderingMemoryContext memoryContext,IOrderingRepository repository)
    {
        _memoryContext = memoryContext;
    }

    public Task<Order> Add(Order entity)
    {
        throw new NotImplementedException();
    }

    public Task<Order> Delete(string id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Order>> GetAll(string search, int page = 1)
    {
        throw new NotImplementedException();
    }

    public Task<Order> GetById(string id)
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
