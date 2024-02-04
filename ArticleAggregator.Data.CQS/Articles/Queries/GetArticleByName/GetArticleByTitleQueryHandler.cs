using ArticleAggregator.Data.CustomExceptions;
using ArticleAggregator.Data.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArticleAggregator.Data.CQS.Articles.Queries.GetArticleByName;

public class GetArticleByTitleQueryHandler : IRequestHandler<GetArticleByTitleQuery, Article>
{
    private readonly ArticlesAggregatorDbContext _dbContext;

    public GetArticleByTitleQueryHandler(ArticlesAggregatorDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Article> Handle(GetArticleByTitleQuery request, CancellationToken cancellationToken)
    {
        var article = await _dbContext.Articles.FirstOrDefaultAsync(article => article.Title.Equals(request.ArticleTitle), cancellationToken)
            ?? throw new NotFoundException("Article");

        return article;
    }
}
