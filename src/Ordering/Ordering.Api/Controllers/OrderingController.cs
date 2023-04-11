using App.Ordering.Api.Core.Data;
using App.Ordering.Api.Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace App.Ordering.Api.Controller;
[ApiController]
[Route("api/OrderingController")]
public class OrderingController : ControllerBase
{
    private readonly IOrderDetailService _orderDetailService;
    private readonly IOrderingService _orderingService;

    public OrderingController(IOrderingService orderingService, IOrderDetailService orderDetailService)
    {
        _orderDetailService= orderDetailService;
        _orderingService = orderingService;
    }
    [HttpGet]
    public async Task<IActionResult> GetOrder(string search, int page)
    {
        var listOrderDetail = await _orderingService.GetAll(search, page);
        return Ok(listOrderDetail);
    }
     [HttpGet("/{orderId}")]
    public async Task<IActionResult> GetProductById(string orderId)
    {
        Order order = new Order();
        var orderDetails = new List<OrderDetail>();
        if (!String.IsNullOrEmpty(orderId))
        {
            order = await _orderingService.GetById(orderId);
            orderDetails =await _orderDetailService.GetOrderDetailByOrderCode(orderId);
        }
        return Ok(order);
    }
    // call api add orderDetail
    [HttpPost]
    public async Task<IActionResult> AddOrder(OrderDetail orderDetail, Order order)
    {
        Order orderResult = new Order();
        if (order != null)
        {
            orderResult = await _orderingService.Add(order);
        }
        return Ok(orderResult);
    }
}