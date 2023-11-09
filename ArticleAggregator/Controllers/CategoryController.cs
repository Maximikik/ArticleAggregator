using ArticleAggregator.Data.Entities;
using ArticleAggregator.Models;
using ArticleAggregator_Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArticleAggregator.Controllers;

public class CategoryController : Controller
{
    private readonly ILogger<ArticleController> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public CategoryController(ILogger<ArticleController> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<IActionResult> CategoriesPreview()
    {
        var categoriesList = await _unitOfWork.CategoryRepository
        .FindBy(category => !string.IsNullOrEmpty(category.Name))
        .Select(category => new CategoryModel()
        {
            Id = category.Id,
            Name = category.Name,
            PositivityRating = category.PositivityRating
        })
        .ToListAsync();
        return View(categoriesList);
    }
}
