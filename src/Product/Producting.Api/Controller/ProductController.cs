using App.Producting.Api.Core.Service;
using App.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace App.Producting.Api.Controller;

[ApiController]
[Route("api/[controller]")]

public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
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
        Product productResult = new Product();
        if (productId != null && cost > 0)
        {
            productResult = await _productService.UpdateCost(productId, cost);
        }
        return Ok(productResult);
    }

    [HttpPatch]
    [Route("/Invetory/{productId}")]
    public async Task<IActionResult> UpdateInventory(string productId, long inventory)
    {
        Product productResult = new Product();
        if (productId != null && inventory > 0)
        {
            productResult = await _productService.UpdateInventory(productId, inventory);
        }
        return Ok(productResult);
    }
    [HttpPatch]
    [Route("/RetailPrice/{productId}")]
    public async Task<IActionResult> UpdateRetailPrice(string productId, long retailPrice)
    {
        Product productResult = new Product();
        if (productId != null && retailPrice > 0)
        {
            productResult = await _productService.UpdateRetailPrice(productId, retailPrice);
        }
        return Ok(productResult);
    }
    [HttpPatch]
    [Route("/Status/{productId}")]
    public async Task<IActionResult> UpdateStatus(string productId, bool status)
    {
        Product productResult = new Product();
        if (productId != null)
        {
            productResult = await _productService.UpdateStatus(productId, status);
        }
        return Ok(productResult);
    }
    [HttpDelete]
    [Route("/{productId}")]
    public async Task<IActionResult> DeleteProduct(string productId)
    {
         Product productResult = new Product();
        if (productId != null)
        {
            productResult = await _productService.Delete(productId);
        }
        return Ok(productResult);
    }
}