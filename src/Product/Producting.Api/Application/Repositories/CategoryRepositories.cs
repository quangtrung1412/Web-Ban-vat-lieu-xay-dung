using App.Producting.Api.Core.Data;
using App.Producting.Api.Core.Repositories;
using App.Shared.Entities;

namespace App.Producting.Api.Application.Repositories;

public class CategoryRepositories : ICategoryRepositories
{
    private readonly ProductDbContext _dbContext;
    private readonly ILogger<CategoryRepositories> _logger;

    public CategoryRepositories(ProductDbContext dbContext, ILogger<CategoryRepositories> logger)
    {
        _dbContext =dbContext;
        _logger =logger;
    }
    public async Task<Category> Add(Category entity)
    {
        try
        {
            _dbContext.Categories.Add(entity);
            return await Task.FromResult(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return null;
        }
    }

    public async Task<Category> Delete(string id)
    {
        var category = await GetById(id);
        try
        {
            if (category != null)
            {
                _dbContext.Categories.Remove(category);
            }
            return category;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return null;
        }
    }


    public async Task<Category> GetById(string id)
    {
        var category = await _dbContext.Categories.FindAsync(id);
        return category;
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