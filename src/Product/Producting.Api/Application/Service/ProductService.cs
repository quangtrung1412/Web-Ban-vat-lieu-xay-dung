using App.Producting.Api.Core.Service;
using App.Producting.Producting.Api.Core.Data;
using App.Shared.Entities;

namespace App.Producting.Api.Application.Service;

public class ProductService : IProductService
{
    public ProductService(ProductMemoryContext memoryContext , ILogger<ProductService> logger)
    {
        
    }
    public Task<Product> Add(Product entity)
    {
        throw new NotImplementedException();
    }

    public Task<Product> Delete(string id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Product>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetById(string id)
    {
        throw new NotImplementedException();
    }

    public void SaveChangesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Product> Update(Product entity)
    {
        throw new NotImplementedException();
    }

    public Task<Product> UpdateCost(string productCode, long cost)
    {
        throw new NotImplementedException();
    }

    public Task<Product> UpdateInventory(string productCode, long inventory)
    {
        throw new NotImplementedException();
    }

    public Task<Product> UpdateRetailPrice(string productCode, long retailPrice)
    {
        throw new NotImplementedException();
    }

    public Task<Product> UpdateStatus(string productCode, bool status)
    {
        throw new NotImplementedException();
    }
}