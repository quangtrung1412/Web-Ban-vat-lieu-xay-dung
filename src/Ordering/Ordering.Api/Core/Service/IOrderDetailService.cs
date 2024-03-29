using App.Shared.Core.Service;
using App.Shared.Entities;

namespace App.Ordering.Api.Core.Service;

public interface IOrderDetailService : IService<OrderDetail>
{
    Task<OrderDetail> UpdateNumberProduct(string orderDetailCode, long numberProduct);
    Task<OrderDetail> UpdateTotalPrice(string orderDetailCode, long totalPrice);
    Task<OrderDetail> UpdateSale(string orderDetailCode, long sale);
    Task<List<OrderDetail>> GetOrderDetailByOrderCode(string orderCode);
    Task<List<OrderDetail>> DeleteListOrderDetail(string orderCode);
}