using ArticleAggregator.Data;
using ArticleAggregator.Data.Entities;
using ArticleAggregator_Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ArticleAggregator_Repositories.Repositories;

public class ArticleRepository : Repository<Article>, IArticleRepository
{
    public ArticleRepository(ArticlesAggregatorDbContext dbContext)
        : base(dbContext)
    {
    }

    public async Task<Article> GetByTitle(string title)
    {
        return await _dbSet.FirstOrDefaultAsync(article => article.Title.Equals(title))
            ?? throw new ArgumentNullException();
    }

    public Task<Article> RateArticle(Article article)
    {
        throw new NotImplementedException();
    }
}