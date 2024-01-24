using ArticleAggregator.Data.CQS.Articles.Queries;
using ArticleAggregator.Data.CustomExceptions;
using ArticleAggregator.Data.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArticleAggregator.Data.CQS.Articles.Handlers.Queries;

public class GetArticleByIdQueryHandler : IRequestHandler<GetArticleByIdQuery, Article>
{
    private readonly ArticlesAggregatorDbContext _dbContext;

    public GetArticleByIdQueryHandler(ArticlesAggregatorDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Article> Handle(GetArticleByIdQuery request, CancellationToken cancellationToken)
    {
        var article = await _dbContext.Articles
            .FirstOrDefaultAsync(article1 => article1.Id.Equals(request.Id),
                cancellationToken)
            ?? throw new NotFoundException("Article", request.Id);
        //convert to DTO

        return article;
    }
}