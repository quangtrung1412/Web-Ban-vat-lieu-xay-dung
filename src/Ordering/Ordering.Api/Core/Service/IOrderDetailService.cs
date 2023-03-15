using App.Ordering.Api.Core.Data;
using App.Shared.Core.Service;

namespace App.Ordering.Api.Core.Service;

public interface IOrderDetailService : IService<OrderDetail>
{
    Task<OrderDetail> UpdateNumberProduct (long numberProduct);
    Task<OrderDetail> UpdateOrderDate(DateTime dateTime);
    Task<OrderDetail> UpdateTotalPrice(long totalPrice);
    Task<OrderDetail> UpdateSale(long sale);
}