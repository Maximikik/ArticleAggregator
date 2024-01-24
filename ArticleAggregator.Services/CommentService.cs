using ArticleAggregator.Core.Dto;
using ArticleAggregator.Data.CQS.Comments.Commands;
using ArticleAggregator.Mapping;
using ArticleAggregator.Services.Interfaces;
using ArticleAggregator_Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace ArticleAggregator.Services;

public class CommentService : ICommentService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly CommentMapper _commentMapper;
    private readonly IMediator _mediator;
    private readonly IConfiguration _configuration;
    public CommentService(IUnitOfWork unitOfWork,
      CommentMapper commentMapper, IMediator mediator, IConfiguration configuration)
    {
        _unitOfWork = unitOfWork;
        _commentMapper = commentMapper;
        _mediator = mediator;
        _configuration = configuration;
    }
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
