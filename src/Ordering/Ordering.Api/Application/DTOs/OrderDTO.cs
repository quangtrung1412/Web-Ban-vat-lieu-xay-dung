using App.Ordering.Api.Core.Data;
using App.Shared.Entities;

namespace App.Ordering.Api.Application.DTOs;

public class OrderDTO
{
    public Order Order {get;set;}
    public List<OrderDetail> OrderDetails {get;set;}
}