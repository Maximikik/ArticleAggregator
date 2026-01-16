using ArticleAggregator.Core.Dto;
using ArticleAggregator.Mapping;
using FeedAggregator.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArticleAggregator.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FeedController(IFeedService _feedService, FeedMapper _feedMapper) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetFeedById(Guid id)
    {
        var feedDto = await _feedService.GetFeedById(id);

        return Ok(feedDto);
    }

    [HttpGet]
    // [Authorize(Roles = "User")]
    public async Task<IActionResult> GetAll()
    {
        var feedDtos = await _feedService.GetAll();
        return Ok(feedDtos);
    }


    [HttpPost]
    public async Task<IActionResult> CreateFeed([FromQuery] string title)
    {
        var dto = new FeedDto
        {
            Id = Guid.NewGuid(),
            Title = title
        };

        await _feedService.CreateFeed(dto);

        return Created();
    }

    [HttpPatch]
    public async Task<IActionResult> AddArticleToFeed([FromQuery] Guid articleId, [FromQuery] Guid feedId)
    {
        var dto = await _feedService.AddArticleToFeed(articleId, feedId);

        return Created();
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFeed(Guid id)
    {
        await _feedService.DeleteFeed(id);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveArticleFromFeed([FromQuery] Guid articleId, [FromQuery] Guid feedId)
    {
        var dto = await _feedService.RemoveArticleFromFeed(articleId, feedId);

        return Created();
    }
}
