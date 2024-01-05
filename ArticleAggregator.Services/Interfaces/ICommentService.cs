using ArticleAggregator.Core;

namespace ArticleAggregator.Services.Interfaces;

public interface ICommentService
{
    public Task<CommentDto?> AddCommentToArticle(Guid articleId);
    public Task<Guid?> RemoveCommentFromArticle(Guid commentId);
}
