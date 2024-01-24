using ArticleAggregator.Core.Dto;
using MediatR;

namespace ArticleAggregator.Data.CQS.Comments.Commands;

public class AddCommentToArticleCommand : IRequest
{
    public CommentDto CommentDto { get; set; } = null!;
}
