using ArticleAggregator.Data.Entities;

namespace ArticleAggregator_Repositories.Interfaces;

public interface ICommentRepository : IRepository<Comment>
{
    Task AddCommentToArticle(Comment comment, Article article);
    Task<List<Comment>> GetArticleComments(Article article);

}
