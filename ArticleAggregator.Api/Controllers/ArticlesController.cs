using ArticleAggregator.Core.Models;
using ArticleAggregator.Mapping;
using ArticleAggregator.Services.Interfaces;
using Hangfire;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

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

    [HttpGet("ById")]
    public async Task<IActionResult> GetArticleById(Guid id)
    {
        var articleDto = await _articleService.GetArticleById(id);
        var article = _articleMapper.ArticleDtoToArticle(articleDto!);

        return Ok(article);
    }

    [HttpGet]
    // [Authorize(Roles = "User")]
    public async Task<IActionResult> GetAll()
    {
        var articlesDto = await _articleService.GetAll();

        var articles = articlesDto!.Select(dto => _articleMapper.ArticleDtoToArticle(dto));

        return Ok(articles);
    }

    [HttpGet("Positive")]
   // [Authorize(Roles = "User")]
    public async Task<IActionResult> GetPositiveArticles([FromBody] int rateGreaterThan)
    {
        var articlesDto = await _articleService.GetPositiveArticles(rateGreaterThan);

        var articles = articlesDto!.Select(dto => _articleMapper.ArticleDtoToArticle(dto));

        return Ok(articles);
    }

    //[HttpGet("{amount}")]
    ////[Authorize(Roles = "User")]
    //public async Task<IActionResult> GetLatestArticles(int amount = 15)
    //{
    //    //var articles = (await _articleService.GetPositive())
    //    //    .Select(dto => _articleMapper.ArticleDtoToArticleModel(dto))
    //    //    .ToArray();

    //    var articles = await _articleService.GetLatest();

    //    RecurringJob.AddOrUpdate(
    //        "TestRecurringJob",
    //        () => await _articleService.RateText(), "* 8-17 * * Mon-Fri");


    //    return Ok(articles);
    //}

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

    [HttpPatch]
    public async Task<IActionResult> UpdateArticle(Dictionary<Guid, string> ArticlesData)
    {
        await _articleService.UpdateArticleDescription(ArticlesData);

        return Ok();
    }
}
