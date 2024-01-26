using ArticleAggregator.Core.Dto;
using MediatR;

namespace ArticleAggregator.Data.CQS.Comments.Commands.AddCommentToArticle;

public class AddCommentToArticleCommand : IRequest
{
    public CommentDto CommentDto { get; set; } = null!;
}
