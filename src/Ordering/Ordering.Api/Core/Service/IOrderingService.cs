using App.Ordering.Api.Core.Data;
using App.Ordering.Api.Core.Repositories;
using App.Shared.Core.Service;

namespace App.Ordering.Api.Core.Service;

public interface IOrderingService:IService<Order>
{
    Task<Order> UpdateDeliveryDate(DateTime deliveryDate);
    Task<Order> UpdatePaid(long paid);
    Task<Order> UpdateStatus(int status);
    Task<Order> UpdateOrderDate(DateTime dateTime);
    Task<Order> UpdateTotalPrice(long totalPrice);
    Task<Order> UpdateSale(long sale);
}