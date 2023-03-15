using App.Producting.Api.Core.Repositories;
using App.Shared.Entities;

namespace App.Producting.Api.Application.Repositories;

public class ProductRepositories : IProductRepositories
{
    public ProductRepositories(){
        
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

    public Task<Product> Update(Product entity)
    {
        throw new NotImplementedException();
    }
}