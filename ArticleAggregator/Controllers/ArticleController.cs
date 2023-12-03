using ArticleAggregator.Data.Entities;
using ArticleAggregator.Models;
using ArticleAggregator_Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ArticleAggregator.Controllers;

public class ArticleController : Controller
{
    private readonly ILogger<ArticleController> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public ArticleController(ILogger<ArticleController> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<IActionResult> ArticlesPreview()
    {
        var articlesList = await _unitOfWork.ArticleRepository
        .FindBy(article => !string.IsNullOrEmpty(article.Title),
            article => article.ArticleSource)
        .Select(article => new ArticleModel()
        {
            Id = article.Id,
            Title = article.Title,
            ArticleSourceId = article.ArticleSourceId,
            Rating = article.Rating
        })
        .ToListAsync();
        return View(articlesList);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] ArticleModel articleModel)
    {
        var article = new Article
        {
            Id = articleModel.Id,
            Title = articleModel.Title,
            Rating = articleModel.Rating,
            ArticleSourceId = articleModel.ArticleSourceId
        };

        await _unitOfWork.ArticleRepository.InsertOne(article);
        await _unitOfWork.Commit();

        //return View();
        return RedirectToAction("ArticlesPreview");
    }

    [HttpGet]
    public async Task<IActionResult> Delete()
    {
        var articles = _unitOfWork.ArticleRepository.GetAll();

        var model = new DeleteModel()
        {
            DeleteList = new List<SelectListItem>()
        };

        foreach (var item in articles)
        {
            model.DeleteList.Add(new SelectListItem { Text = item.Title, Value = item.Id.ToString() });
        }

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Delete([FromForm] DeleteModel DeleteModel)
    {
        await _unitOfWork.ArticleRepository.DeleteById(DeleteModel.Selected);
        await _unitOfWork.Commit();

        return RedirectToAction("ArticlesPreview");
    }
}
