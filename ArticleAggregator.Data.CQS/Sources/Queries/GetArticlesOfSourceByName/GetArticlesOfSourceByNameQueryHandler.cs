using ArticleAggregator.Data.CustomExceptions;
using ArticleAggregator.Data.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArticleAggregator.Data.CQS.Sources.Queries.GetArticlesOfSourceByName;

internal class GetArticlesOfSourceByNameQueryHandler : IRequestHandler<GetArticlesOfSourceByNameQuery, List<Article>>
{
    private readonly ArticlesAggregatorDbContext _dbContext;

    public GetArticlesOfSourceByNameQueryHandler(ArticlesAggregatorDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Article>> Handle(GetArticlesOfSourceByNameQuery request, CancellationToken cancellationToken)
    {
        var source = await _dbContext.Sources.FirstOrDefaultAsync(source => source.Name.Equals(request.Name), cancellationToken)
            ?? throw new NotFoundException("Source", request.Name);

        return source.Articles;
    }
}
