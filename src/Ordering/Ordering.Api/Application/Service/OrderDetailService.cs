using App.Ordering.Api.Core.Data;
using App.Ordering.Api.Core.Service;

namespace App.Ordering.Api.Application.Service;

public class OrderDetailService : IOrderDetailService
{
    private readonly OrderingMemoryContext _memoryContext;

    public OrderDetailService(OrderingMemoryContext memoryContext)
    {
        _memoryContext = memoryContext;
    }
    public Task<OrderDetail> Add(OrderDetail entity)
    {
        throw new NotImplementedException();
    }

    public Task<OrderDetail> Delete(string id)
    {
        throw new NotImplementedException();
    }

    public Task<List<OrderDetail>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<OrderDetail> GetById(string id)
    {
        throw new NotImplementedException();
    }

    public Task<OrderDetail> Update(OrderDetail entity)
    {
        throw new NotImplementedException();
    }

    public Task<OrderDetail> UpdateNumberProduct(long numberProduct)
    {
        throw new NotImplementedException();
    }

    public Task<OrderDetail> UpdateOrderDate(DateTime dateTime)
    {
        throw new NotImplementedException();
    }

    public Task<OrderDetail> UpdateSale(long sale)
    {
        throw new NotImplementedException();
    }

    public Task<OrderDetail> UpdateTotalPrice(long totalPrice)
    {
        throw new NotImplementedException();
    }
}