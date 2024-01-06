using ArticleAggregator.Data.CQS.Categories.Commands;
using ArticleAggregator.Mapping;
using ArticleAggregator.Models;
using ArticleAggregator.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArticleAggregator.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;
    private readonly CategoryMapper _categoryMapper;

    public CategoriesController(ICategoryService categoryService,
        CategoryMapper categoryMapper)
    {
        _categoryService = categoryService;
        _categoryMapper = categoryMapper;
    }

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
    public async Task<IActionResult> CreateCategory([FromBody] CategoryModel categoryModel)
    {
        var dto = _categoryMapper.CategoryModelToCategoryDto(categoryModel);

        await _categoryService.CreateCategory(dto);

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
