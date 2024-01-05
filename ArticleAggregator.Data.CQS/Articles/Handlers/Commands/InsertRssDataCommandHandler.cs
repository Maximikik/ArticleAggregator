using ArticleAggregator.Data.CQS.Articles.Commands;
using ArticleAggregator.Mapping;
using MediatR;

namespace ArticleAggregator.Data.CQS.Articles.Handlers.Commands;

public class InsertRssDataCommandHandler : IRequestHandler<InsertRssDataCommand>
{
    private readonly ArticlesAggregatorDbContext _dbContext;
    private readonly ArticleMapper _mapper;

    public InsertRssDataCommandHandler(ArticlesAggregatorDbContext dbContext,
        ArticleMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task Handle(InsertRssDataCommand request, CancellationToken cancellationToken)
    {
        var articles = request.Articles
            .Select(dto => _mapper.ArticleDtoToArticle(dto))
            .ToArray();
        await _dbContext.Articles.AddRangeAsync(articles, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
