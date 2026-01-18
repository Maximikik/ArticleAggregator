using ArticleAggregator.Core.Dto;
using ArticleAggregator.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArticleAggregator.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController(ICategoryService _categoryService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllCategories()
    {
        var categories = await _categoryService.GetAllCategories();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoryById(Guid id)
    {
        var category = await _categoryService.GetCategoryById(id);
        return Ok(category);
    }

    [HttpGet("{name}")]
    public async Task<IActionResult> GetCategoryByName(string name)
    {
        var category = await _categoryService.GetCategoryByName(name);
        return Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody] CategoryDto request)
    {
        await _categoryService.CreateCategory(request);

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategoryById(Guid id)
    {
        await _categoryService.DeleteCategoryById(id);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCategoryByName(string name)
    {
        await _categoryService.DeleteCategoryByName(name);
        return Ok();
    }
}
