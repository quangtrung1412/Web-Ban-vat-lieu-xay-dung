using Microsoft.AspNetCore.Mvc;

namespace App.Producting.Api.Controller;

[ApiController]
[Route("api/productController")]

public class ProductController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetProduct(string search, int page)
    {
        return await Task.FromResult(Ok());
    }
    
}