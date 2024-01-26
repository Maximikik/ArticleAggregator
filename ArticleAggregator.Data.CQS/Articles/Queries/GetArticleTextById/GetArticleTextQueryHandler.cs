using ArticleAggregator.Data.CustomExceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArticleAggregator.Data.CQS.Articles.Queries.GetArticleTextById;

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
            ?? throw new NotFoundException("Article", request.Id);

        return article.Title;

        //convert to DTO
    }
}
