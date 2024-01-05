using ArticleAggregator.Data.CQS.Sources.Queries;
using ArticleAggregator.Data.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArticleAggregator.Data.CQS.Sources.Handlers.Queries;

public class GetAllSourcesQueryHandler : IRequestHandler<GetAllSourcesQuery, List<Source>>
{
    private readonly ArticlesAggregatorDbContext _dbContext;

    public GetAllSourcesQueryHandler(ArticlesAggregatorDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Source>> Handle(GetAllSourcesQuery request, CancellationToken cancellationToken)
    {
        return await _dbContext.Sources.ToListAsync();
    }
}
