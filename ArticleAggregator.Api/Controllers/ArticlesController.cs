using ArticleAggregator.Core.Dto;
using ArticleAggregator.Services.Interfaces;
using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace ArticleAggregator.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ArticlesController(IArticleService _articleService) : ControllerBase
{
    [HttpGet("ById")]
    public async Task<IActionResult> GetArticleById(Guid id)
    {
        return Ok(await _articleService.GetArticleById(id));
    }

    [HttpGet]
    // [Authorize(Roles = "User")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _articleService.GetAll());
    }

    [HttpGet("Positive")]
    // [Authorize(Roles = "User")]
    public async Task<IActionResult> GetPositiveArticles([FromBody] int rateGreaterThan)
    {
        return Ok(await _articleService.GetPositiveArticles(rateGreaterThan));
    }

    [HttpPost]
    public async Task<IActionResult> CreateArticle(ArticleDto request)
    {
        await _articleService.CreateArticle(request);

        string urlToResourse = "";
        return Created(urlToResourse, null);
    }

    [HttpPost("InsertRss")]
    public async Task<IActionResult> InsertArticlesFromRssFeed(Guid sourceId)
    {
        await _articleService.InsertArticlesFromRssByArticleSourceId(sourceId);

        RecurringJob.AddOrUpdate(
        "RssJob",
            () => _articleService.InsertArticlesFromRssByArticleSourceId(sourceId), "0 0 * * *");

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
