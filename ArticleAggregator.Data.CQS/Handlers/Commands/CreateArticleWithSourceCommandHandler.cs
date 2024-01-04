using ArticleAggregator.Data.CQS.Commands;
using ArticleAggregator.Data.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArticleAggregator.Data.CQS.Handlers.Commands;

public class CreateArticleWithSourceCommandHandler : IRequestHandler<CreateArticleWithSourceCommand>
{
    private readonly ArticlesAggregatorDbContext _dbContext;

    public CreateArticleWithSourceCommandHandler(ArticlesAggregatorDbContext articlesAggregatorDbContext)
    {
        _dbContext = articlesAggregatorDbContext;
    }

    public async Task Handle(CreateArticleWithSourceCommand request, CancellationToken cancellationToken)
    {
        var isSourceExists = await _dbContext.Sources.AnyAsync(source => source.Id.Equals(request.ArticleSourceId), cancellationToken);

        if (!isSourceExists)
        {
            throw new Exception(); // add custom exception
        }

        var article = new Article
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Rating = request.Rating,
            ArticleSourceId = request.ArticleSourceId
        };

        await _dbContext.Articles.AddAsync(article, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
