using App.Ordering.Api.Application.DTOs;
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
        _orderDetailService = orderDetailService;
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
        var orderDTO = new OrderDTO();
        if (!String.IsNullOrEmpty(orderId))
        {
            orderDTO.Order = await _orderingService.GetById(orderId);
            orderDTO.OrderDetails = await _orderDetailService.GetOrderDetailByOrderCode(orderId);
        }
        return Ok(orderDTO);
    }
    // call api add orderDetail
    [HttpPost]
    public async Task<IActionResult> AddOrder(OrderDTO orderDTO)
    {
        var orderDTOResult = new OrderDTO();
        if (orderDTOResult != null)
        {
            orderDTOResult.Order = await _orderingService.Add(orderDTO.Order);
            if (orderDTO.OrderDetails != null)
            {
                foreach (var orderDetail in orderDTO.OrderDetails)
                {
                    var orderDetailResult = await _orderDetailService.Add(orderDetail);
                    orderDTOResult.OrderDetails.Add(orderDetailResult);
                }
            }
        }
        return Ok(orderDTOResult);
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteOrder (string orderId)
    {
        return BadRequest();
    }
}