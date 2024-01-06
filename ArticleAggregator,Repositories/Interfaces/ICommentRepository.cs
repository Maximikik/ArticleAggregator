using ArticleAggregator.Data.Entities;

namespace ArticleAggregator_Repositories.Interfaces;

public interface ICommentRepository
{
    Task AddCommentToArticle(Comment comment, Article article);
}
