using App.Shared.Core.Service;
using App.Shared.Entities;

namespace App.Producting.Api.Core.Service;

public interface IProductService : IService<Product>
{
    Task<Product> UpdateInventory(string productCode, long inventory);
    Task<Product> UpdateStatus(string productCode, bool status);
    Task<Product> UpdateCost(string productCode, long cost);
    Task<Product> UpdateRetailPrice(string productCode, long retailPrice);
    Task<List<Product>> GetAll(string search);
}