using App.Shared.Core.Repositories;
using App.Shared.Entities;

namespace App.Producting.Api.Core.Repositories;

public interface IProductRepositories : IRepositories<Product>
{
    Task<Product> UpdateInventory(string productCode , long inventory );
    Task<Product> UpdateStatus (string productCode,bool status);
    Task<Product> UpdateCost(string productCode , long cost);
    Task<Product> UpdateRetailPrice(string productCode , long retailPrice);
}