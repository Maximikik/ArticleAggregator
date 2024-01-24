using ArticleAggregator.Data.Entities;

namespace ArticleAggregator_Repositories.Interfaces;

public interface IArticleRepository : IRepository<Article>
{
    Task<Article> GetByTitle(string title);
    Task<List<Article>> RateArticle(Article article);
}
