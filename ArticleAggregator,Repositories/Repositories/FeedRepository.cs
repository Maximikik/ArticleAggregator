using ArticleAggregator.Data;
using ArticleAggregator.Data.Entities;
using ArticleAggregator_Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ArticleAggregator_Repositories.Repositories;

public class FeedRepository : Repository<Feed>, IFeedRepository
{
    private readonly ArticlesAggregatorDbContext _dbContext;

    public FeedRepository(ArticlesAggregatorDbContext dbContext)
        : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Feed> GetFeedWithArticles(Guid feedId)
    {
        var feed = await _dbSet.Include(x => x.Articles).FirstOrDefaultAsync(a => a.Id == feedId)
            ?? throw new Exception("Feed is not found");

        return feed;
    }

    public async Task<Feed> AddArticleToFeed(Guid articleId, Guid feedId)
    {
        var article = await _dbContext.Articles.FirstOrDefaultAsync(a => a.Id == articleId)
            ?? throw new Exception("Article is not found");
        var feed = await _dbSet.Include(x => x.Articles).FirstOrDefaultAsync(a => a.Id == feedId)
            ?? throw new Exception("Feed is not found");

        article.FeedId = feedId;

        return feed;
    }

    public async Task<Feed> RemoveArticleFromFeed(Guid articleId, Guid feedId)
    {
        var article = await _dbContext.Articles.FirstOrDefaultAsync(a => a.Id == articleId)
            ?? throw new Exception("Article is not found");
        var feed = await _dbSet.Include(x => x.Articles).FirstOrDefaultAsync(a => a.Id == feedId)
            ?? throw new Exception("Feed is not found");



        if (feed.Articles != null && feed.Articles.Select(x => x.Id).ToList().Contains(articleId))
        {
            feed.Articles!.ToList().Remove(article);
        }

        return feed;
    }
}
