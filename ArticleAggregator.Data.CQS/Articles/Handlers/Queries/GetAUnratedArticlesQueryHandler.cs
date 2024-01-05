using ArticleAggregator.Data.CQS.Articles.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArticleAggregator.Data.CQS.Articles.Handlers.Queries;

public class GetAUnratedArticlesQueryHandler : IRequestHandler<GetAUnratedArticlesQuery, Guid[]>
{
    private readonly ArticlesAggregatorDbContext _dbContext;

    public GetAUnratedArticlesQueryHandler(ArticlesAggregatorDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Guid[]> Handle(GetAUnratedArticlesQuery request, CancellationToken cancellationToken)
    {
        return await _dbContext.Articles
            .AsNoTracking()
            .Where(article => article.Rating == null)
            .Take(request.MaxTake)
            .Select(article => article.Id)
            .ToArrayAsync(cancellationToken);
    }
}
