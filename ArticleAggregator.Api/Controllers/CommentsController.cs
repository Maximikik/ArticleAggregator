using ArticleAggregator.Core.Dto;
using ArticleAggregator.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArticleAggregator.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentsController(ICommentService _commentService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddCommentToArticle(CommentDto commentDto)
    {
        await _commentService.AddCommentToArticle(commentDto);

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveCommentFromArticle(Guid commentId)
    {
        await _commentService.RemoveCommentFromArticle(commentId);

        return Ok();
    }
}
