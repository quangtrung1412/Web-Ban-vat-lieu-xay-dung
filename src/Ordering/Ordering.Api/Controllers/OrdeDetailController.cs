using App.Ordering.Api.Core.Data;
using App.Ordering.Api.Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace App.Ordering.Api.Controller;
[ApiController]
[Route("api/OrderDetailController")]
public class OrderDetailController : ControllerBase
{
    private readonly IOrderDetailService _orderDetailService;

    public OrderDetailController(IOrderDetailService orderDetailService)
    {
        _orderDetailService = orderDetailService;
    }
    [HttpGet]
    public async Task<IActionResult> GetOrderDetail(string search, int page)
    {
        var listOrderDetail = await _orderDetailService.GetAll(search, page);
        return Ok(listOrderDetail);
    }
    [HttpPost]
    public async Task<IActionResult> AddOrderDetail(OrderDetail orderDetail)
    {
        OrderDetail orderDetailResult = new OrderDetail();
        if (orderDetail != null)
        {
            orderDetailResult = await _orderDetailService.Add(orderDetail);
        }
        return Ok(orderDetailResult);
    }
    [HttpDelete]
    [Route("/{orderDetailId}")]
    public async Task<IActionResult> DeleteOrderDetail(string orderDetailId)
    {
        OrderDetail orderDetailResult = new OrderDetail();
        if (orderDetailId != null)
        {
            orderDetailResult = await _orderDetailService.Delete(orderDetailId);
        }
        return Ok(orderDetailResult);
    }
    [HttpPatch]
    [Route("/NumberProduct/{orderDetailId}")]
    public async Task<IActionResult> UpdateNumberProduct(string orderDetailId, long numberProduct)
    {
        OrderDetail orderDetailResult = new OrderDetail();
        if (orderDetailId != null && numberProduct > 0)
        {
            orderDetailResult = await _orderDetailService.UpdateNumberProduct(orderDetailId, numberProduct);
        }
        return Ok(orderDetailResult);
    }
    [HttpPatch]
    [Route("/Sale/{orderDetailId}")]
    public async Task<IActionResult> UpdateSale(string orderDetailId, long sale)
    {
        OrderDetail orderDetailResult = new OrderDetail();
        if (orderDetailId != null)
        {
            orderDetailResult = await _orderDetailService.UpdateSale(orderDetailId, sale);
        }
        return Ok(orderDetailResult);
    }
    [HttpPatch]
    [Route("/TotalPrice/{orderDetailId}")]
    public async Task<IActionResult> UpdateTotalPrice(string orderDetailId, long totalPrice)
    {
        OrderDetail orderDetailResult = new OrderDetail();
        if (orderDetailId != null && totalPrice > 0)
        {
            orderDetailResult = await _orderDetailService.UpdateTotalPrice(orderDetailId, totalPrice);
        }
        return Ok(orderDetailResult);
    }
}