using ArticleAggregator.Data.CQS.Articles.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArticleAggregator.Data.CQS.Articles.Handlers.Commands;

public class UpdateArticleTextCommandHandler : IRequestHandler<UpdateArticleTextCommand>
{
    private readonly ArticlesAggregatorDbContext _dbContext;

    public UpdateArticleTextCommandHandler(ArticlesAggregatorDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(UpdateArticleTextCommand request, CancellationToken cancellationToken)
    {
        var articles = await _dbContext.Articles.Where(article => request.ArticlesData.Keys
             .Contains(article.Id))
             .ToListAsync(cancellationToken)
             ?? throw new Exception(); // custom exception

        foreach (var article in articles)
        {
            article.Title = request.ArticlesData[article.Id];
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
