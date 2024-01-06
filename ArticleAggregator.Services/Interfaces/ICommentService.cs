using ArticleAggregator.Core;

namespace ArticleAggregator.Services.Interfaces;

public interface ICommentService
{
    public Task AddCommentToArticle(CommentDto commentDto);
    public Task RemoveCommentFromArticle(Guid commentId);
}
