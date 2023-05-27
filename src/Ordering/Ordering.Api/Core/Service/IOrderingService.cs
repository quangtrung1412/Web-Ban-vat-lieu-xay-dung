using App.Shared.Core.Service;
using App.Shared.Entities;

namespace App.Ordering.Api.Core.Service;

public interface IOrderingService : IService<Order>
{
    Task<Order> UpdateDeliveryDate(string orderCode, DateTime deliveryDate);
    Task<Order> UpdatePaid(string orderCode, long paid);
    Task<Order> UpdateOrderDate(string orderCode, DateTime dateTime);
    Task<Order> UpdateTotalPrice(string orderCode, long totalPrice);
    Task<Order> UpdateSale(string orderCode, long sale);
    Task<Order> UpdateStatus(string orderCode, OrderingStatus status);
}