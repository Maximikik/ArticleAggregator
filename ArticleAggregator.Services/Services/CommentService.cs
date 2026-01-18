using ArticleAggregator.Core.Dto;
using ArticleAggregator.Data.CQS.Comments.Commands.AddCommentToArticle;
using ArticleAggregator.Data.CQS.Comments.Commands.RemoveCommentFromArticle;
using ArticleAggregator.Mapping;
using ArticleAggregator.Services.Interfaces;
using ArticleAggregator_Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace ArticleAggregator.Services.Services;

public class CommentService(
    IUnitOfWork _unitOfWork,
IMapper _commentMapper,
IMediator _mediator,
IConfiguration _configuration
    ) : ICommentService
{
    public async Task AddCommentToArticle(CommentDto commentDto)
    {
        var command = new AddCommentToArticleCommand
        {
            CommentDto = commentDto
        };

        await _mediator.Send(command);
    }

    public async Task RemoveCommentFromArticle(Guid commentId)
    {
        var command = new RemoveCommentFromArticleCommand
        {
            CommentId = commentId
        };

        await _mediator.Send(command);
    }
}
