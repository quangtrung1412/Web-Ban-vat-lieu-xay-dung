using App.Ordering.Api.Core.Data;
using App.Shared.Core.Repositories;

namespace App.Ordering.Api.Core.Repositories;

public interface IOrderDetailRepository : IRepositories<OrderDetail>
{
    Task<OrderDetail> UpdateNumberProduct(string orderDetailCode, long numberProduct);
    Task<OrderDetail> UpdateTotalPrice(string orderDetailCode, long totalPrice);
    Task<OrderDetail> UpdateSale(string orderDetailCode, long sale);
}