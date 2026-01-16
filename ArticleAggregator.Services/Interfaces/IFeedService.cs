using ArticleAggregator.Core.Dto;

namespace FeedAggregator.Services.Interfaces;

public interface IFeedService
{
    public Task InsertFeedsFromRssByFeedSourceId(Guid sourceId);

    public Task<IEnumerable<FeedDto>> GetAll();
    public Task<FeedDto?> GetFeedById(Guid id);
    public Task<FeedDto?> GetFeedByTitle(string name);

    public Task CreateFeed(FeedDto dto);
    public Task<FeedDto> AddArticleToFeed(Guid articleId, Guid feedId);
    public Task<FeedDto> RemoveArticleFromFeed(Guid articleId, Guid feedId);
    public Task DeleteFeed(Guid id);
}
