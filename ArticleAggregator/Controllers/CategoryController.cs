using ArticleAggregator.Data.Entities;
using ArticleAggregator.Models;
using ArticleAggregator_Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ArticleAggregator.Controllers;

public class CategoryController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoryController(IUnitOfWork unitOfWork)
    {
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

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] CategoryModel categoryModel)
    {
        var category = new Category
        {
            Id = categoryModel.Id,
            Name = categoryModel.Name,
            PositivityRating = categoryModel.PositivityRating,
        };

        await _unitOfWork.CategoryRepository.InsertOne(category);
        await _unitOfWork.Commit();

        return RedirectToAction("CategoriesPreview");
    }

    [HttpGet]
    public async Task<IActionResult> Delete()
    {
        var categories = _unitOfWork.CategoryRepository.GetAll();

        var model = new DeleteModel()
        {
            DeleteList = new List<SelectListItem>()
        };

        foreach (var item in categories)
        {
            model.DeleteList.Add(new SelectListItem { Text = item.Name, Value = item.Id.ToString() });
        }

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Delete([FromForm] DeleteModel DeleteModel)
    {
        await _unitOfWork.CategoryRepository.DeleteById(DeleteModel.Selected);
        await _unitOfWork.Commit();

        return RedirectToAction("CategoriesPreview");
    }
}
