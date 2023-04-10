using App.Ordering.Api.Core.Data;
using App.Ordering.Api.Core.Repositories;
using App.Ordering.Api.Core.Service;
using App.Shared.Core.Handle;
using App.Shared.Utils;

namespace App.Ordering.Api.Application.Service;

public class OrderingService : IOrderingService
{
    private readonly OrderingMemoryContext _memoryContext;
    private readonly IOrderingRepository _repository;
    private readonly ILogger<OrderingService> _logger;

    public OrderingService(OrderingMemoryContext memoryContext, IOrderingRepository repository, ILogger<OrderingService> logger)
    {
        _memoryContext = memoryContext;
        _repository = repository;
        _logger = logger;
    }

    public async Task<Order> Add(Order entity)
    {
        var orderCode = "";
        var numberMax = _memoryContext.Orders.Keys.Max();
        var numberOrder = Int32.Parse(numberMax.Substring(2)) + 1;

        var numberOrderCode = GenerateCode.GenerateCodeFollowNumber(numberOrder);
        orderCode = Constants.ProductKey + numberOrderCode;
        entity.OrderCode = orderCode;
        Order order = new Order();
        var isAdded = _memoryContext.Orders.TryAdd(orderCode, entity);
        if (isAdded)
        {
            order = await _repository.Add(entity);
            if (order != null)
                _repository.SaveChangesAsync();
            else
                _memoryContext.Orders.Remove(orderCode);
        }
        return order;
    }

    public async Task<Order> Delete(string id)
    {
        Order order = new Order();
        if (String.IsNullOrEmpty(id))
        {
            order = await GetById(id);
            if (order != null)
            {
                _memoryContext.Orders.Remove(id);
                var OrderDb = await _repository.Delete(id);
                if (OrderDb != null)
                    _repository.SaveChangesAsync();
                else
                    _memoryContext.Orders.Add(id, order);
            }
        }
        return order;
    }

    public async Task<List<Order>> GetAll(string search, int page = 1)
    {
        var pageSize = 10;
        List<Order> listOrder = new List<Order>();
        listOrder = _memoryContext.Orders.Values.Where(o => string.IsNullOrEmpty(search) || o.Email.Contains(search)
        || o.Seller.Contains(search) || o.Phone.Contains(search)).ToList();

        var data = listOrder.OrderBy(p => p.OrderCode)
                              .Skip((page - 1) * pageSize)
                              .Take(pageSize).ToList();
        return await Task.FromResult(data);
    }

    public async Task<Order> GetById(string id)
    {
        if (!String.IsNullOrEmpty(id))
        {
            if (_memoryContext.Orders.TryGetValue(id, out Order order))
                return order;
            else
            {
                order = await _repository.GetById(id);
                _memoryContext.Orders.Add(order.OrderCode, order);
                return order;
            }
        }
        return null;
    }

    public async Task<Order> UpdateDeliveryDate(string orderCode, DateTime deliveryDate)
    {
        var order = await GetById(orderCode);
        if (order != null)
        {
            var oldDeliveryDate = order.DeliveryDate;
            var orderDb = await _repository.UpdateDeliveryDate(orderCode, deliveryDate);
            if (orderDb != null)
                _repository.SaveChangesAsync();
            else
                order.DeliveryDate = oldDeliveryDate;
        }
        return order;
    }

    public async Task<Order> UpdateOrderDate(string orderCode, DateTime dateTime)
    {
        var order = await GetById(orderCode);
        if (order != null)
        {
            var oldOrderDate = order.OrderDate;
            var orderDb = await _repository.UpdateOrderDate(orderCode, dateTime);
            if (orderDb != null)
                _repository.SaveChangesAsync();
            else
                order.OrderDate = oldOrderDate;
        }
        return order;
    }

    public async Task<Order> UpdatePaid(string orderCode, long paid)
    {
        var order = await GetById(orderCode);
        if (order != null)
        {
            var oldPaid = order.Paid;
            var orderDb = await _repository.UpdatePaid(orderCode, paid);
            if (orderDb != null)
                _repository.SaveChangesAsync();
            else
                order.Paid = oldPaid;
        }
        return order;
    }

    public async Task<Order> UpdateSale(string orderCode, long sale)
    {
        var order = await GetById(orderCode);
        if (order != null)
        {
            var oldSale = order.Sale;
            var orderDb = await _repository.UpdateSale(orderCode, sale);
            if (orderDb != null)
                _repository.SaveChangesAsync();
            else
                order.Sale = oldSale;
        }
        return order;
    }

    public async Task<Order> UpdateStatus(string orderCode, OrderingStatus status)
    {
        var order = await GetById(orderCode);
        if (order != null)
        {
            var oldStatus = order.Status;
            var orderDb = await _repository.UpdateStatus(orderCode, status);
            if (orderDb != null)
                _repository.SaveChangesAsync();
            else
                order.Status = oldStatus;
        }
        return order;
    }

    public async Task<Order> UpdateTotalPrice(string orderCode, long totalPrice)
    {
        var order = await GetById(orderCode);
        if (order != null)
        {
            var oldTotalPrice = order.TotalPrice;
            var orderDb = await _repository.UpdateTotalPrice(orderCode, totalPrice);
            if (orderDb != null)
                _repository.SaveChangesAsync();
            else
                order.TotalPrice = oldTotalPrice;
        }
        return order;
    }
}
