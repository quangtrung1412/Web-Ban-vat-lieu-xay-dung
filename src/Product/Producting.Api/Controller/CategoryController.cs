using App.Producting.Api.Core.Data.Entities;
using App.Producting.Api.Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace App.Producting.Api.Controller;
[ApiController]
[Route("api/CategoryController")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    [HttpGet]
    public async Task<IActionResult> GetCategory(string search, int page)
    {
        var listCategory= await _categoryService.GetAll(search, page);
        return Ok(listCategory);
    }
    [HttpPost]
    public async Task<IActionResult> AddCategory(Category category)
    {
        Category categoryResult = new Category();
        if (category != null)
        {
            categoryResult = await _categoryService.Add(category);
        }
        return Ok(categoryResult);
    }
    [HttpDelete]
    [Route("/{categoryId}")]
    public async Task<IActionResult> DeleteProduct(string categoryId)
    {
        Category categoryResult = new Category();
        if (categoryId != null)
        {
            categoryResult = await _categoryService.Delete(categoryId);
        }
        return Ok(categoryResult);
    }
}