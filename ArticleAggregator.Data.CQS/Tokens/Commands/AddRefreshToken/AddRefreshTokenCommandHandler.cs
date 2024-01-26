using ArticleAggregator.Data.Entities;
using MediatR;

namespace ArticleAggregator.Data.CQS.Tokens.Commands.AddRefreshToken;

public class AddRefreshTokenCommandHandler : IRequestHandler<AddRefreshTokenCommand, Guid>
{
    private readonly ArticlesAggregatorDbContext _dbContext;

    public AddRefreshTokenCommandHandler(ArticlesAggregatorDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Handle(AddRefreshTokenCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var rt = new RefreshToken()
            {
                Id = Guid.NewGuid(),
                GeneratedAt = DateTime.UtcNow,
                ExpiringAt = DateTime.UtcNow.AddHours(1),//should be in config
                AssociatedDeviceName = command.Ip,
                ClientId = command.ClientId

            };
            await _dbContext.RefreshTokens.AddAsync(rt, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return rt.Id;
        }
        catch (Exception e)
        {
            //log
            return Guid.Empty;
        }
    }
}
