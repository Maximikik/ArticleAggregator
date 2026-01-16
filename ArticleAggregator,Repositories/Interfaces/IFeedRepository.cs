using ArticleAggregator.Data.Entities;

namespace ArticleAggregator_Repositories.Interfaces;

public interface IFeedRepository : IRepository<Feed>
{
    Task<Feed> AddArticleToFeed(Guid articleId, Guid feedId);
    Task<Feed> RemoveArticleFromFeed(Guid articleId, Guid feedId);
    Task<Feed> GetFeedWithArticles(Guid feedId);
}
