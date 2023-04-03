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

    public Task<List<OrderDetail>> GetAll(string search, int page = 1)
    {
        throw new NotImplementedException();
    }

    public Task<OrderDetail> GetById(string id)
    {
        throw new NotImplementedException();
    }

    public Task<OrderDetail> UpdateNumberProduct(string orderDetailCode,long numberProduct)
    {
        throw new NotImplementedException();
    }

    public Task<OrderDetail> UpdateOrderDate(string orderDetailCode, DateTime dateTime)
    {
        throw new NotImplementedException();
    }

    public Task<OrderDetail> UpdateSale(string orderDetailCode, long sale)
    {
        throw new NotImplementedException();
    }

    public Task<OrderDetail> UpdateTotalPrice(string orderDetailCode, long totalPrice)
    {
        throw new NotImplementedException();
    }
}