using ArticleAggregator.Data.CQS.Commands;
using ArticleAggregator.Mapping;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArticleAggregator.Data.CQS.Handlers.Commands;

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
            ?? throw new Exception(); // add NotFoundException or smth

        article.Rating = request.Rate;

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
