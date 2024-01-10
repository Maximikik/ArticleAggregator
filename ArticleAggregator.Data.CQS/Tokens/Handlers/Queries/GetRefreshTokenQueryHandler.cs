using ArticleAggregator.Data.CQS.Queries;
using ArticleAggregator.Data.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ArticleAggregator.Data.CQS.CustomExceptions;

namespace ArticleAggregator.Data.CQS.QueryHandlers;

public class GetRefreshTokenQueryHandler : IRequestHandler<GetRefreshTokenQuery, RefreshToken>
{
    private readonly ArticlesAggregatorDbContext _dbContext;

    public GetRefreshTokenQueryHandler(ArticlesAggregatorDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<RefreshToken> Handle(GetRefreshTokenQuery request,
        CancellationToken cancellationToken)
    {
        var refreshToken = await _dbContext.RefreshTokens
            .FirstOrDefaultAsync(article1 => article1.Id.Equals(request.Id),
                cancellationToken: cancellationToken)
            ?? throw new NotFoundException("Token", request.Id);

        return refreshToken;
    }
}