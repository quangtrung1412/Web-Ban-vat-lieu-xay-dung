using App.Ordering.Api.Core.Data;
using App.Shared.Core.Repositories;

namespace App.Ordering.Api.Core.Repositories;

public interface IOrderingRepository : IRepositories<Order>
{
    Task<Order> UpdateDeliveryDate(string orderCode, DateTime deliveryDate);
    Task<Order> UpdatePaid(string orderCode, long paid);
    Task<Order> UpdateOrderDate(string orderCode, DateTime dateTime);
    Task<Order> UpdateTotalPrice(string orderCode, long totalPrice);
    Task<Order> UpdateSale(string orderCode, long sale);
    Task<Order> UpdateStatus(string orderCode, OrderingStatus status);
}