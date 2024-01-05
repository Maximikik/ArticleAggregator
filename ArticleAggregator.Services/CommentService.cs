using ArticleAggregator.Core;
using ArticleAggregator.Services.Interfaces;

namespace ArticleAggregator.Services;

public class CommentService : ICommentService
{
    public Task<CommentDto?> AddCommentToArticle(Guid articleId)
    {
        throw new NotImplementedException();
    }

    public Task<Guid?> RemoveCommentFromArticle(Guid commentId)
    {
        throw new NotImplementedException();
    }
}
