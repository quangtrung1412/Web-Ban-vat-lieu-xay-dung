using App.Producting.Api.Core.Data;
using App.Producting.Api.Core.Repositories;
using App.Shared.Entities;

namespace App.Producting.Api.Application.Repositories;

public class TradeMarkRepositories : ITradeMarkRepositories
{
    private readonly ProductDbContext _dbContext;
    private readonly ILogger<TradeMarkRepositories> _logger;

    public TradeMarkRepositories(ProductDbContext dbContext ,ILogger<TradeMarkRepositories> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
        
    }
    public async Task<TradeMark> Add(TradeMark entity)
    {
       try
        {
            _dbContext.TradeMarks.Add(entity);
            return await Task.FromResult(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return null;
        }
    }

    public async Task<TradeMark> Delete(string id)
    {
        var tradeMark = await GetById(id);
        try
        {
            if (tradeMark != null)
            {
                _dbContext.TradeMarks.Remove(tradeMark);
            }
            return tradeMark;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return null;
        }
    }

    public async Task<TradeMark> GetById(string id)
    {
        var tradeMark = await _dbContext.TradeMarks.FindAsync(id);
        return tradeMark;
    }

    public async void SaveChangesAsync()
    {
        try
        {
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
        }
    }

}