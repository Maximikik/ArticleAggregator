namespace ArticleAggregator.Data.CQS.Feeds.Commands.AddArticleToFeed;

public class AddArticleToFeedCommand// : IRequest<FeedDto>
{
    public Guid ArticleId { get; set; }
    public Guid FeedId { get; set; }
}
