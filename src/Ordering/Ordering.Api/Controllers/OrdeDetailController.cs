using App.Ordering.Api.Core.Data;
using App.Ordering.Api.Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace App.Ordering.Api.Controller;
[ApiController]
[Route("api/OrderDetailController")]
public class OrderDetailController : ControllerBase
{
    private readonly IOrderDetailService _orderDetailService;
    private readonly IOrderingService _orderingService;

    public OrderDetailController(IOrderDetailService orderDetailService, IOrderingService orderingService)
    {
        _orderDetailService = orderDetailService;
        _orderingService = orderingService;
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
            var order = await _orderingService.UpdateTotalPrice(orderDetailResult.OrderCode,orderDetailResult.GetTotalPrice());
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