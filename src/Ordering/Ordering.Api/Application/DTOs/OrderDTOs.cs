using App.Ordering.Api.Core.Data;

namespace App.Ordering.Api.Application.DTOs;

public class OrderDTOs
{
    public Order Order {get;set;}
    public List<OrderDetail> OrderDetails {get;set;}
}