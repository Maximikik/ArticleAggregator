using ArticleAggregator.Data.CQS.Articles.Queries.GetPositive;
using ArticleAggregator.Data.CustomExceptions;
using ArticleAggregator.Data.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArticleAggregator.Data.CQS.Articles.Queries.GetPositiveArticles;

public class GetPositiveArticlesQueryHandler : IRequestHandler<GetPositiveArticlesQuery, List<Article>>
{
    private readonly ArticlesAggregatorDbContext _dbContext;

    public GetPositiveArticlesQueryHandler(ArticlesAggregatorDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Article>> Handle(GetPositiveArticlesQuery request, CancellationToken cancellationToken)
    {
        var articles = await _dbContext.Articles.Where(article => article.Rating >= request.rateGreaterThan).ToListAsync()
            ?? throw new NotFoundException("Article");

        return articles;
    }
}
