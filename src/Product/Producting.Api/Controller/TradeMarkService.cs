using App.Producting.Api.Core.Data.Entities;
using App.Producting.Api.Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace App.Producting.Api.Controller;
[ApiController]
[Route("api/tradeMarkController")]
public class TradeMarkController : ControllerBase
{
    private readonly ITradeMarkService _tradeMarkService;

    public TradeMarkController(ITradeMarkService tradeMarkService)
    {
        _tradeMarkService = tradeMarkService;
    }
    [HttpGet]
    public async Task<IActionResult> GetTradeMark(string search, int page)
    {
        var listTradeMark = await _tradeMarkService.GetAll(search, page);
        return Ok(listTradeMark);
    }
    [HttpPost]
    public async Task<IActionResult> AddTradeMark(TradeMark tradeMark)
    {
        TradeMark tradeMarkResult = new TradeMark();
        if (tradeMark != null)
        {
            tradeMarkResult = await _tradeMarkService.Add(tradeMark);
        }
        return Ok(tradeMarkResult);
    }
    [HttpDelete]
    [Route("/{TradeMarkId}")]
    public async Task<IActionResult> DeleteProduct(string tradeMarkId)
    {
        TradeMark tradeMarkResult = new TradeMark();
        if (tradeMarkId != null)
        {
            tradeMarkResult = await _tradeMarkService.Delete(tradeMarkId);
        }
        return Ok(tradeMarkResult);
    }
}