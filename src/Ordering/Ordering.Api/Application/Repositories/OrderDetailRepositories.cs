using App.Ordering.OrderingApi.Core.Data;
using App.Ordering.OrderingApi.Core.Repositories;

namespace App.Ordering.OrderingApi.Application.Repositories;

public class OrderDetailRepository : IOrderDetailRepository
{
    private readonly OrderingMemoryContext _memoryContext;
    private readonly OrderingDbContext _dbContext;

    public OrderDetailRepository(OrderingMemoryContext memoryContext,OrderingDbContext dbContext)
    {
        _memoryContext= memoryContext;
        _dbContext =dbContext;
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