using App.Ordering.Api.Core.Data;
using App.Shared.Core.Repositories;

namespace App.Ordering.Api.Core.Repositories;

public interface IOrderDetailRepository:IRepositories<OrderDetail>
{
    Task<OrderDetail> UpdateOrderDate(DateTime dateTime);
    Task<OrderDetail> UpdateTotalPrice(long totalPrice);
    Task<OrderDetail> UpdateSale(long sale);
}