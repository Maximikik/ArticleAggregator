using ArticleAggregator.Data.CustomExceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArticleAggregator.Data.CQS.Articles.Commands.SetArticleRate;

public class SetArticleRateCommandHandler : IRequestHandler<SetArticleRateCommand>
{
    private readonly ArticlesAggregatorDbContext _dbContext;

    public SetArticleRateCommandHandler(ArticlesAggregatorDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task Handle(SetArticleRateCommand request, CancellationToken cancellationToken)
    {
        var article = await _dbContext.Articles.FirstOrDefaultAsync(article => article.Id.Equals(request.Id), cancellationToken)
            ?? throw new NotFoundException("Article", request.Id);

        article.Rating = request.Rate;

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
