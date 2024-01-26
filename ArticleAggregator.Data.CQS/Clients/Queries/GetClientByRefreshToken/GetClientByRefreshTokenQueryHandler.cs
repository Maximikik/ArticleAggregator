using ArticleAggregator.Data.CustomExceptions;
using ArticleAggregator.Data.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArticleAggregator.Data.CQS.Clients.Queries.GetClientByRefreshToken;

public class GetClientByRefreshTokenQueryHandler : IRequestHandler<GetUserByRefreshTokenQuery, Client>
{
    private readonly ArticlesAggregatorDbContext _dbContext;

    public GetClientByRefreshTokenQueryHandler(ArticlesAggregatorDbContext articlesAggregatorDbContext)
    {
        _dbContext = articlesAggregatorDbContext;
    }

    public async Task<Client> Handle(GetUserByRefreshTokenQuery request, CancellationToken cancellationToken)
    {
        var refreshToken = await _dbContext.RefreshTokens
            .FirstOrDefaultAsync(rt => rt.Id.Equals(request.RefreshTokenId),
                cancellationToken: cancellationToken)
            ?? throw new NotFoundException("Token", request.RefreshTokenId);


        var client = await _dbContext.Clients
            .FirstOrDefaultAsync(u => u.Id.Equals(refreshToken.ClientId),
                cancellationToken)
            ?? throw new NotFoundException("Client", refreshToken.ClientId);
        return client;
    }
}