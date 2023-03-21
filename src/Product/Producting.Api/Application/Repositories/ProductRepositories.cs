using App.Producting.Api.Core.Data;
using App.Producting.Api.Core.Repositories;
using App.Shared.Entities;

namespace App.Producting.Api.Application.Repositories;

public class ProductRepositories : IProductRepositories
{
    private readonly ProductDbContext _dbContext;
    private readonly ILogger<ProductDbContext> _logger;

    public ProductRepositories(ProductDbContext dbContext, ILogger<ProductDbContext> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }
    public async Task<Product> Add(Product entity)
    {
        try
        {
            _dbContext.Products.Add(entity);
            return await Task.FromResult(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return null;
        }
    }

    public async Task<Product> Delete(string id)
    {
        var product = await GetById(id);
        try
        {
            if (product != null)
            {
                _dbContext.Products.Remove(product);
            }
            return product;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return null;
        }
    }
    public async Task<Product> GetById(string id)
    {
        var product = await _dbContext.Products.FindAsync(id);
        return product;
    }

    public async Task<Product> UpdateInventory(string productCode, long inventory)
    {
        var product = await GetById(productCode);
        try
        {
            if (product != null)
            {
                product.Inventory = inventory;
            }
            return product;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return null;
        }
    }
    public async Task<Product> UpdateStatus(string productCode, bool status)
    {
        var product = await GetById(productCode);
        try
        {
            if (product != null)
            {
                product.Status = status;
            }
            return product;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return null;
        }
    }
    public async Task<Product> UpdateCost(string productCode, long cost)
    {
        var product = await GetById(productCode);
        try
        {
            if (product != null)
            {
                product.Cost = cost;
            }
            return product;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return null;
        }
    }
    public async Task<Product> UpdateRetailPrice(string productCode, long retailPrice)
    {
        var product = await GetById(productCode);
        try
        {
            if (product != null)
            {
                product.RetailPrice = retailPrice;
            }
            return product;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return null;
        }
    }
    public void SaveChangesAsync()
    {
        try
        {
            _dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
        }
    }
}