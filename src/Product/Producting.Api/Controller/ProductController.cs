using App.Producting.Api.Core.Data.Entities;
using App.Producting.Api.Core.Service;
using App.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace App.Producting.Api.Controller;

[ApiController]
[Route("api/productController")]

public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;
    private readonly ITradeMarkService _tradeMarkService;

    public ProductController(IProductService productService, ICategoryService categoryService, ITradeMarkService tradeMarkService)
    {
        _productService = productService;
        _categoryService = categoryService;
        _tradeMarkService = tradeMarkService;
    }
    [HttpGet]
    public async Task<IActionResult> GetProduct(string search, int page)
    {
        var listProduct = await _productService.GetAll(search, page);
        return Ok(listProduct);
    }
    [HttpGet("/{productId}")]
    public async Task<IActionResult> GetProductById(string productId)
    {
        Product product = new Product();
        if (!String.IsNullOrEmpty(productId))
        {
            product = await _productService.GetById(productId);
        }
        return Ok(product);
    }
    [HttpPost]
    public async Task<IActionResult> AddProduct(Product product)
    {
        Product productResult = new Product();
        if (product != null)
        {
            productResult = await _productService.Add(product);
        }
        return Ok(productResult);
    }
    [HttpPatch]
    [Route("/Cost/{productId}")]
    public async Task<IActionResult> UpdateCost(string productId, long cost)
    {
        return await Task.FromResult(Ok());
    }

    [HttpPatch]
    [Route("/Invetory/{productId}")]
    public async Task<IActionResult> UpdateInventory(string productId, long inventory)
    {
        return await Task.FromResult(Ok());
    }
    [HttpPatch]
    [Route("/RetailPrice/{productId}")]
    public async Task<IActionResult> UpdateRetailPrice(string productId, long retailPrice)
    {
        return await Task.FromResult(Ok());
    }
    [HttpPatch]
    [Route("/Status/{productId}")]
    public async Task<IActionResult> UpdateStatus(string productId, bool status)
    {
        return await Task.FromResult(Ok());
    }
    [HttpDelete]
    [Route("/{productId}")]
    public async Task<IActionResult> DeleteProduct(string productId)
    {
        return await Task.FromResult(Ok());
    }
}