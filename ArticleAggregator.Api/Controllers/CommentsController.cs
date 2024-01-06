using ArticleAggregator.Core;
using ArticleAggregator.Mapping;
using ArticleAggregator.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArticleAggregator.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentsController : ControllerBase
{
    private readonly ICommentService _commentService;
    private readonly CommentMapper _commentMapper;

    public CommentsController(ICommentService commentService,
        CommentMapper commentMapper)
    {
        _commentService = commentService;
        _commentMapper = commentMapper;
    }

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
