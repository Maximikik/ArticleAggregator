using ArticleAggregator.Mapping;
using ArticleAggregator.Models;
using ArticleAggregator.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArticleAggregator.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ArticlesController : ControllerBase
{
    private readonly IArticleService _articleService;
    private readonly ArticleMapper _articleMapper;

    public ArticlesController(IArticleService articleService,
        ArticleMapper articleMapper)
    {
        _articleService = articleService;
        _articleMapper = articleMapper;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetArticleById(Guid id)
    {
        var article = _articleMapper.ArticleDtoToArticleModel(
            await _articleService.GetArticleById(id));
        return Ok(article);
    }

    [HttpGet]
    //[Authorize(Roles = "User")]
    public async Task<IActionResult> GetArticles()
    {
        var articles = (await _articleService.GetPositive())
            .Select(dto => _articleMapper.ArticleDtoToArticleModel(dto))
            .ToArray();

        return Ok(articles);
    }

    [HttpPost]
    public async Task<IActionResult> CreateArticle(ArticleModel request)
    {
        var dto = _articleMapper.ArticleModelToArticleDto(request);

        await _articleService.CreateArticle(dto);

        string urlToResourse = "";
        return Created(urlToResourse, null);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteArticle(Guid id)
    {
        await _articleService.DeleteArticle(id);
        return Ok();
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateArticle()
    {
        return Ok();
    }
}
