using App.Ordering.Api.Core.Data;
using App.Ordering.Api.Core.Repositories;
using App.Ordering.Api.Core.Service;
using App.Shared.Core.Handle;
using App.Shared.Utils;

namespace App.Ordering.Api.Application.Service;

public class OrderDetailService : IOrderDetailService
{
    private readonly OrderingMemoryContext _memoryContext;
    private readonly IOrderDetailRepository _orderDetailRepository;

    public OrderDetailService(OrderingMemoryContext memoryContext, IOrderDetailRepository orderDetailRepository)
    {
        _memoryContext = memoryContext;
        _orderDetailRepository = orderDetailRepository;
    }

    public async Task<OrderDetail> Add(OrderDetail entity)
    {
        var orderDetailCode = "";
        var orderDetailLength = _memoryContext.OrderDetails.Count();
        var numberMax = _memoryContext.OrderDetails.Keys.Max();
        var numberOrderDetail = Int32.Parse(numberMax.Substring(2)) + 1;

        var numberOrderDetailCode = GenerateCode.GenerateCodeFollowNumber(numberOrderDetail);
        orderDetailCode = Constants.ProductKey + numberOrderDetailCode;

        OrderDetail OrderDetail = new OrderDetail();
        var isAdded = _memoryContext.OrderDetails.TryAdd(orderDetailCode, entity);
        if (isAdded)
        {
            OrderDetail = await _orderDetailRepository.Add(entity);
            if (OrderDetail != null)
                _orderDetailRepository.SaveChangesAsync();
            else
                _memoryContext.OrderDetails.Remove(orderDetailCode);
        }
        return OrderDetail;
    }

    public async Task<OrderDetail> Delete(string id)
    {
        OrderDetail orderDetail = new OrderDetail();
        if (String.IsNullOrEmpty(id))
        {
            orderDetail = await GetById(id);
            if (orderDetail != null)
            {
                _memoryContext.OrderDetails.Remove(id);
                var orderDetailDb = await _orderDetailRepository.Delete(id);
                if (orderDetailDb != null)
                    _orderDetailRepository.SaveChangesAsync();
                else
                    _memoryContext.OrderDetails.Add(id, orderDetail);
            }
        }
        return orderDetail;
    }

    public async Task<List<OrderDetail>> GetAll(string search, int page = 1)
    {
        var pageSize = 10;
        List<OrderDetail> listOrderDetail = new List<OrderDetail>();
        listOrderDetail = _memoryContext.OrderDetails.Values.Where(o => string.IsNullOrEmpty(search) || o.OrderDetailCode.Contains(search)
        || o.ProductCode.Contains(search)).ToList();

        var data = listOrderDetail.OrderBy(p => p.OrderDetailCode)
                              .Skip((page - 1) * pageSize)
                              .Take(pageSize).ToList();
        return await Task.FromResult(data);
    }

    public async Task<OrderDetail> GetById(string id)
    {
        if (!String.IsNullOrEmpty(id))
        {
            if (_memoryContext.OrderDetails.TryGetValue(id, out OrderDetail orderDetail))
                return orderDetail;
            else
            {
                orderDetail = await _orderDetailRepository.GetById(id);
                _memoryContext.OrderDetails.Add(orderDetail.OrderDetailCode, orderDetail);
                return orderDetail;
            }
        }
        return null;
    }

    public async Task<OrderDetail> UpdateNumberProduct(string orderDetailCode, long numberProduct)
    {
        var orderDetail = await GetById(orderDetailCode);
        if (orderDetail != null)
        {
            var oldNumberProduct = orderDetail.NumberProduct;
            var orderDetailDb = await _orderDetailRepository.UpdateNumberProduct(orderDetailCode, numberProduct);
            if (orderDetailDb != null)
                _orderDetailRepository.SaveChangesAsync();
            else
                orderDetail.NumberProduct = oldNumberProduct;
        }
        return orderDetail;
    }

    public async Task<OrderDetail> UpdateSale(string orderDetailCode, long sale)
    {
        var orderDetail = await GetById(orderDetailCode);
        if (orderDetail != null)
        {
            var oldSale= orderDetail.Sale;
            var orderDetailDb = await _orderDetailRepository.UpdateSale(orderDetailCode, sale);
            if (orderDetailDb != null)
                _orderDetailRepository.SaveChangesAsync();
            else
                orderDetail.Sale = oldSale;
        }
        return orderDetail;
    }

    public async Task<OrderDetail> UpdateTotalPrice(string orderDetailCode, long totalPrice)
    {
       var orderDetail = await GetById(orderDetailCode);
        if (orderDetail != null)
        {
            var oldTotalPrice= orderDetail.TotalPrice;
            var orderDetailDb = await _orderDetailRepository.UpdateNumberProduct(orderDetailCode, totalPrice);
            if (orderDetailDb != null)
                _orderDetailRepository.SaveChangesAsync();
            else
                orderDetail.TotalPrice = oldTotalPrice;
        }
        return orderDetail;
    }
}