using App.Shared.Entities;

namespace App.Ordering.Api.Core.Data;

public class OrderingMemoryContext
{
    public Dictionary<string,Order> Orders = new Dictionary<string, Order>();
    public Dictionary<string,OrderDetail> OrderDetails = new Dictionary<string, OrderDetail>();
    public static string GetOrderKey(string orderCode)=> $"{orderCode}";
    public static string GetOrderDetailKey(string orderDetailCode)=> $"{orderDetailCode}";
}