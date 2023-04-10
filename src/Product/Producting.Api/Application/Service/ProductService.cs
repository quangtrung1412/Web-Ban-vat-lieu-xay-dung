using System.Reflection.Metadata;
using App.Producting.Api.Core.Repositories;
using App.Producting.Api.Core.Service;
using App.Producting.Producting.Api.Core.Data;
using App.Shared.Core.Handle;
using App.Shared.Entities;
using App.Shared.Utils;

namespace App.Producting.Api.Application.Service;

public class ProductService : IProductService
{
    private readonly ProductMemoryContext _memoryContext;
    private readonly IProductRepositories _productRepositories;
    private readonly ICategoryRepositories _categoryRepositories;
    private readonly ITradeMarkRepositories _tradeMarkRepositories;
    private readonly ILogger<ProductService> _logger;

    public ProductService(ProductMemoryContext memoryContext, IProductRepositories productRepositories, ILogger<ProductService> logger)
    {
        _memoryContext = memoryContext;
        _productRepositories = productRepositories;
        _logger = logger;
    }
    public async Task<Product> Add(Product entity)
    {
        var productCode = "";
        var productLength = _memoryContext.Products.Count();
        var numberMax = _memoryContext.Products.Keys.Max();
        var numberProduct = Int32.Parse(numberMax.Substring(2)) + 1;

        var numberProductCode = GenerateCode.GenerateCodeFollowNumber(numberProduct);
        productCode = Constants.ProductKey + numberProductCode;

        Product product = new Product();
        var isAdded = _memoryContext.Products.TryAdd(productCode, entity);
        if (isAdded)
        {
            product = await _productRepositories.Add(entity);
            if (product != null)
                _productRepositories.SaveChangesAsync();
            else
                _memoryContext.Products.Remove(productCode);
        }
        return product;
    }

    public async Task<Product> Delete(string id)
    {
        Product product = new Product();
        if (String.IsNullOrEmpty(id))
        {
            product = await GetById(id);
            if (product != null)
            {
                _memoryContext.Products.Remove(id);
                var productDb = await _productRepositories.Delete(id);
                if (productDb != null)
                    _productRepositories.SaveChangesAsync();
                else
                    _memoryContext.Products.Add(id, product);
            }
        }
        return product;
    }
    public async Task<Product> GetById(string id)
    {
        if (!String.IsNullOrEmpty(id))
        {
            if (_memoryContext.Products.TryGetValue(id, out Product product))
                return product;
            else
            {
                product = await _productRepositories.GetById(id);
                _memoryContext.Products.Add(product.ProductCode, product);
                return product;
            }
        }
        return null;
    }

    public async Task<Product> UpdateCost(string productCode, long cost)
    {
        var product = await GetById(productCode);
        if (product != null)
        {
            var oldCost = product.Cost;
            var productDb = await _productRepositories.UpdateCost(productCode, cost);
            if (productDb != null)
                _productRepositories.SaveChangesAsync();
            else
                product.Cost = oldCost;
        }
        return product;
    }

    public async Task<Product> UpdateInventory(string productCode, long inventory)
    {
        var product = await GetById(productCode);
        if (product != null)
        {
            var oldInventory = product.Inventory;
            var productDb = await _productRepositories.UpdateInventory(productCode, inventory);
            if (productDb != null)
                _productRepositories.SaveChangesAsync();
            else
                product.Inventory = oldInventory;
        }
        return product;
    }

    public async Task<Product> UpdateRetailPrice(string productCode, long retailPrice)
    {
        var product = await GetById(productCode);
        if (product != null)
        {
            var oldRetailPrice = product.RetailPrice;
            var productDb = await _productRepositories.UpdateRetailPrice(productCode, retailPrice);
            if (productDb != null)
                _productRepositories.SaveChangesAsync();
            else
                product.RetailPrice = oldRetailPrice;
        }
        return product;
    }

    public async Task<Product> UpdateStatus(string productCode, bool status)
    {
        var product = await GetById(productCode);
        if (product != null)
        {
            var oldStatus = product.Status;
            var productDb = await _productRepositories.UpdateStatus(productCode, status);
            if (productDb != null)
                _productRepositories.SaveChangesAsync();
            else
                product.Status = oldStatus;
        }
        return product;
    }
    public async Task<List<Product>> GetAll(string search, int page = 1)
    {
        var pageSize = 10;

        List<Product> listProduct = new List<Product>();
        listProduct = _memoryContext.Products.Values.Where(p => string.IsNullOrEmpty(search) || p.ProductName.Contains(search)
        || p.TradeMarkName.Contains(search) || p.CategoryName.Contains(search)).ToList();

        var data = listProduct.OrderBy(p => p.ProductCode)
                              .Skip((page - 1) * pageSize)
                              .Take(pageSize).ToList();
        return await Task.FromResult(data);
    }
}