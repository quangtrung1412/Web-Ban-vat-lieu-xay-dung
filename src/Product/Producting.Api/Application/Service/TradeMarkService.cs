using App.Producting.Api.Core.Data.Entities;
using App.Producting.Api.Core.Repositories;
using App.Producting.Api.Core.Service;
using App.Producting.Producting.Api.Core.Data;

namespace App.Producting.Api.Application.Service;

public class TradeMarkService : ITradeMarkService
{
    private readonly ProductMemoryContext _memoryContext;
    private readonly ITradeMarkRepositories _tradeMarkRepositories;

    public TradeMarkService(ProductMemoryContext memoryContext , ITradeMarkRepositories tradeMarkRepositories)
    {
        _memoryContext=memoryContext;
        _tradeMarkRepositories=tradeMarkRepositories;
    }
    public async Task<TradeMark> Add(TradeMark entity)
    {
        var tradeMarkCode = Guid.NewGuid().ToString();
        TradeMark tradeMark = new TradeMark();
        var isAdded = _memoryContext.TradeMarks.TryAdd(tradeMarkCode, entity);
        if (isAdded)
        {
            tradeMark = await _tradeMarkRepositories.Add(entity);
            if (tradeMark != null)
                _tradeMarkRepositories.SaveChangesAsync();
            else
                _memoryContext.TradeMarks.Remove(tradeMarkCode);
        }
        return tradeMark;
    }

    public async Task<TradeMark> Delete(string id)
    {
         TradeMark tradeMark = new TradeMark();
        if (String.IsNullOrEmpty(id))
        {
            tradeMark = await GetById(id);
            if (tradeMark != null)
            {
                _memoryContext.TradeMarks.Remove(id);
                var tradeMarkDb = await _tradeMarkRepositories.Delete(id);
                if (tradeMarkDb == null)
                    _memoryContext.TradeMarks.Add(id, tradeMark);
            }
        }
        return tradeMark;
    }

    public async Task<List<TradeMark>> GetAll(string search, int page = 1)
    {
         var pageSize = 10;

        List<TradeMark> listtradeMark = new List<TradeMark>();
        listtradeMark = _memoryContext.TradeMarks.Values.Where(p => string.IsNullOrEmpty(search) || p.TradeMarkName.Contains(search)).ToList();
       
        var data = listtradeMark.OrderBy(p => p.TradeMarkName)
                              .Skip((page - 1) * pageSize)
                              .Take(pageSize).ToList();
        return await Task.FromResult(data);
    }

    public async Task<TradeMark> GetById(string id)
    {
         if (!String.IsNullOrEmpty(id))
        {
            if (_memoryContext.TradeMarks.TryGetValue(id, out TradeMark tradeMark))
                return tradeMark;
            else
            {
                tradeMark = await _tradeMarkRepositories.GetById(id);
                _memoryContext.TradeMarks.Add(tradeMark.TradeMarkCode, tradeMark);
                return tradeMark;
            }
        }
        return null;
    }
}
