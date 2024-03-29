using App.Shared.Core.Repositories;
using App.Shared.Entities;

namespace App.Ordering.Api.Core.Repositories;

public interface IOrderDetailRepository : IRepositories<OrderDetail>
{
    Task<OrderDetail> UpdateNumberProduct(string orderDetailCode, long numberProduct);
    Task<OrderDetail> UpdateTotalPrice(string orderDetailCode, long totalPrice);
    Task<OrderDetail> UpdateSale(string orderDetailCode, long sale);
    Task<List<OrderDetail>> DeleteListOrderDetail(List<OrderDetail> orderDetails);
}