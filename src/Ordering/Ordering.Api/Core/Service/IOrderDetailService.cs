using App.Ordering.OrderingApi.Core.Data;
using App.Shared.Core.Service;

namespace App.Ordering.OrderingApi.Core.Service;

public interface IOrderDetailService : IService<OrderDetail>
{
    Task<OrderDetail> UpdateNumberProduct (long numberProduct);
}