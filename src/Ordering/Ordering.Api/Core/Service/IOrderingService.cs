using App.Ordering.OrderingApi.Core.Data;
using App.Ordering.OrderingApi.Core.Repositories;
using App.Shared.Core.Service;

namespace App.Ordering.OrderingApi.Core.Service;

public interface IOrderingService:IService<Order>
{
    Task<Order> UpdateDeliveryDate(DateTime deliveryDate);
    Task<Order> UpdatePaid(long paid);
    Task<Order> UpdateStatus(int status);
}