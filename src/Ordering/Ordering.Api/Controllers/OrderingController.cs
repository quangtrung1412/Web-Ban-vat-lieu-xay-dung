using App.Ordering.Api.Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace App.Ordering.Api.Controller;
[ApiController]
[Route("api/OrderingController")]
public class OrderingController : ControllerBase
{
    private readonly IOrderingService _orderingService;

    public OrderingController(IOrderingService orderingService)
    {
        _orderingService = orderingService;
    }
    [HttpGet]
    public async Task<IActionResult> GetOrderDetail(string search, int page)
    {
        var listOrderDetail = await _orderDetailService.GetAll(search, page);
        return Ok(listOrderDetail);
    }
}