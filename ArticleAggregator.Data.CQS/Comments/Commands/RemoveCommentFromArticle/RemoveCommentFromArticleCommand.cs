using MediatR;

namespace ArticleAggregator.Data.CQS.Comments.Commands.RemoveCommentFromArticle;

public class RemoveCommentFromArticleCommand : IRequest
{
    public Guid CommentId { get; set; }
}
