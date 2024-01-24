using ArticleAggregator.Data.CQS.Articles.Commands;
using ArticleAggregator.Data.CustomExceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArticleAggregator.Data.CQS.Articles.Handlers.Commands;

public class DeleteArticleByIdCommandHandler : IRequestHandler<DeleteArticleByIdCommand, Guid>
{
    private readonly ArticlesAggregatorDbContext _dbContext;

    public DeleteArticleByIdCommandHandler(ArticlesAggregatorDbContext articlesAggregatorDbContext)
    {
        _dbContext = articlesAggregatorDbContext;
    }

    public async Task<Guid> Handle(DeleteArticleByIdCommand request, CancellationToken cancellationToken)
    {
        var article = await _dbContext.Articles.FirstOrDefaultAsync(article => article.Id.Equals(request.ArticleId))
            ?? throw new NotFoundException("Article", request.ArticleId);

        _dbContext.Articles.Remove(article);

        return request.ArticleId;
    }
}
