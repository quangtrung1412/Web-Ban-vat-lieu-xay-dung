using App.Ordering.OrderingApi.Core.Data;
using App.Ordering.OrderingApi.Core.Repositories;
using App.Ordering.OrderingApi.Core.Service;

namespace App.Ordering.OrderingApi.Application.Service;

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

    public Task<List<Order>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Order> GetById(string id)
    {
        throw new NotImplementedException();
    }

    public Task<Order> Update(Order entity)
    {
        throw new NotImplementedException();
    }

    public Task<Order> UpdateDeliveryDate(DateTime deliveryDate)
    {
        throw new NotImplementedException();
    }

    public Task<Order> UpdateOrderDate(DateTime orderDate)
    {
        throw new NotImplementedException();
    }

    public Task<Order> UpdatePaid(long paid)
    {
        throw new NotImplementedException();
    }

    public Task<Order> UpdateSale(long sale)
    {
        throw new NotImplementedException();
    }

    public Task<Order> UpdateStatus(int status)
    {
        throw new NotImplementedException();
    }

    public Task<Order> UpdateTotalPrice(long totalPrice)
    {
        throw new NotImplementedException();
    }
}
