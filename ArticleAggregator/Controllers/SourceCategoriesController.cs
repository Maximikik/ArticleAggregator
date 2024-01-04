using ArticleAggregator.Data.Entities;
using ArticleAggregator.Models;
using ArticleAggregator_Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ArticleAggregator.Controllers;

public class SourceCategoriesController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public SourceCategoriesController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<IActionResult> SourceCategoriesPreview()
    {
        var sourceCategoriesList = await _unitOfWork.SourceCategoriesRepository
            .FindBy(sourceCategories => !sourceCategories.Id.Equals(Guid.Empty),
                category => category.Source)
            .Select(source => new SourceCategoriesModel()
            {
                Id = source.Id,
                SourceId = source.SourceId
            })
            .ToListAsync();
        return View(sourceCategoriesList);
    }
}
