using MediatR;

namespace ArticleAggregator.Data.CQS.Comments.Commands;

public class RemoveCommentFromArticleCommand : IRequest
{
    public Guid CommentId { get; set; }
}
