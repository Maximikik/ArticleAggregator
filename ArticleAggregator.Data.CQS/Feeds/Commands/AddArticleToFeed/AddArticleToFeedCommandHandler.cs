using ArticleAggregator.Core.Dto;
using ArticleAggregator.Mapping;

namespace ArticleAggregator.Data.CQS.Feeds.Commands.AddArticleToFeed;

public class AddArticleToFeedCommandHandler(ArticlesAggregatorDbContext _dbContext, IMapper _mapper) //: IRequestHandler<AddArticleToFeedCommand, FeedDto>
{
    public async Task<FeedDto> Handle(AddArticleToFeedCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
