using App.Producting.Api.Core.Data.Entities;
using App.Producting.Api.Core.Repositories;
using App.Producting.Api.Core.Service;
using App.Producting.Producting.Api.Core.Data;

namespace App.Producting.Api.Application.Service;

public class CategoryService : ICategoryService
{
    private readonly ProductMemoryContext _memoryContext;
    private readonly ICategoryRepositories _categoryRepositories;
    private readonly ILogger<CategoryService> _logger;

    public CategoryService(ProductMemoryContext memoryContext, ICategoryRepositories categoryRepositories , ILogger<CategoryService> logger)
    {
        _memoryContext=memoryContext;
        _categoryRepositories=categoryRepositories;
        _logger=logger;
    }
    public async Task<Category> Add(Category entity)
    {
        var categoryCode = Guid.NewGuid().ToString();
        Category category = new Category();
        var isAdded = _memoryContext.Categories.TryAdd(categoryCode, entity);
        if (isAdded)
        {
            category = await _categoryRepositories.Add(entity);
            if (category != null)
                _categoryRepositories.SaveChangesAsync();
            else
                _memoryContext.Categories.Remove(categoryCode);
        }
        return category;
    }

    public async Task<Category> Delete(string id)
    {
        Category category = new Category();
        if (String.IsNullOrEmpty(id))
        {
            category = await GetById(id);
            if (category != null)
            {
                _memoryContext.Categories.Remove(id);
                var categoryDb = await _categoryRepositories.Delete(id);
                if (categoryDb == null)
                    _memoryContext.Categories.Add(id, category);
            }
        }
        return category;
    }

    public async Task<List<Category>> GetAll(string search, int page = 1)
    {
        var pageSize = 10;

        List<Category> listCategory = new List<Category>();
        listCategory = _memoryContext.Categories.Values.Where(p => string.IsNullOrEmpty(search) || p.CategoryName.Contains(search)).ToList();
       
        var data = listCategory.OrderBy(p => p.CategoryName)
                              .Skip((page - 1) * pageSize)
                              .Take(pageSize).ToList();
        return await Task.FromResult(data);
    }


    public async Task<Category> GetById(string id)
    {
        if (!String.IsNullOrEmpty(id))
        {
            if (_memoryContext.Categories.TryGetValue(id, out Category category))
                return category;
            else
            {
                category = await _categoryRepositories.GetById(id);
                _memoryContext.Categories.Add(category.CategoryCode, category);
                return category;
            }
        }
        return null;
    }
}