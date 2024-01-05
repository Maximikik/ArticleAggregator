using ArticleAggregator.Data.CQS.Articles.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArticleAggregator.Data.CQS.Articles.Handlers.Queries;

public class GetArticleTextQueryHandler : IRequestHandler<GetArticleTextQuery, string>
{
    private readonly ArticlesAggregatorDbContext _dbContext;

    public GetArticleTextQueryHandler(ArticlesAggregatorDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<string> Handle(GetArticleTextQuery request,
        CancellationToken cancellationToken)
    {
        var article = await _dbContext.Articles
            .FirstOrDefaultAsync(article1 => article1.Id.Equals(request.Id),
                cancellationToken: cancellationToken)
            ?? throw new Exception();

        return article.Title;

        //convert to DTO
    }
}
