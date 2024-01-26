using ArticleAggregator.Data.CustomExceptions;
using ArticleAggregator.Data.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArticleAggregator.Data.CQS.Sources.Queries.GetArticlesOfSourceById;

public class GetArticlesOfSourceByIdQueryHandler : IRequestHandler<GetArticlesOfSourceByIdQuery, List<Article>>
{
    private readonly ArticlesAggregatorDbContext _dbContext;

    public GetArticlesOfSourceByIdQueryHandler(ArticlesAggregatorDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Article>> Handle(GetArticlesOfSourceByIdQuery request, CancellationToken cancellationToken)
    {
        var source = await _dbContext.Sources.FirstOrDefaultAsync(source => source.Id.Equals(request.Id), cancellationToken)
            ?? throw new NotFoundException("Source", request.Id);

        return source.Articles;
    }
}
