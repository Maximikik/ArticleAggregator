using ArticleAggregator.Data.CQS.Articles.Queries;
using ArticleAggregator.Data.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArticleAggregator.Data.CQS.Articles.Handlers.Queries;

public class GetArticlesByIdQueryHandler : IRequestHandler<GetArticleByIdQuery, Article>
{
    private readonly ArticlesAggregatorDbContext _dbContext;

    public GetArticlesByIdQueryHandler(ArticlesAggregatorDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Article> Handle(GetArticleByIdQuery request, CancellationToken cancellationToken)
    {
        var article = await _dbContext.Articles
            .FirstOrDefaultAsync(article1 => article1.Id.Equals(request.Id),
                cancellationToken)
            ?? throw new Exception();
        //convert to DTO

        return article;
    }
}