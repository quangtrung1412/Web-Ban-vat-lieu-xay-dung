using App.Ordering.Api.Core.Data;
using App.Ordering.Api.Core.Repositories;

namespace App.Ordering.Api.Application.Repositories;

public class OrderingRepository : IOrderingRepository
{
    private readonly OrderingMemoryContext _memoryContext;
    private readonly OrderingDbContext _dbContext;

    public OrderingRepository(OrderingMemoryContext memoryContext,OrderingDbContext dbContext)
    {
        _memoryContext= memoryContext;
        _dbContext =dbContext;
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

    public Task<Order> UpdateOrderDate(DateTime dateTime)
    {
        throw new NotImplementedException();
    }

    public Task<Order> UpdateSale(long sale)
    {
        throw new NotImplementedException();
    }

    public Task<Order> UpdateTotalPrice(long totalPrice)
    {
        throw new NotImplementedException();
    }
}