using App.Ordering.Api.Core.Data;
using App.Shared.Core.Repositories;

namespace App.Ordering.Api.Core.Repositories;

public interface IOrderingRepository:IRepositories<Order>
{
    Task<Order> UpdateOrderDate(DateTime dateTime);
    Task<Order> UpdateTotalPrice(long totalPrice);
    Task<Order> UpdateSale(long sale);
}