using ArticleAggregator.Data.CQS.CustomExceptions;
using ArticleAggregator.Data.CQS.Tokens.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArticleAggregator.Data.CQS.CommandHandlers;


public class DeleteRefreshTokenCommandHandler : IRequestHandler<DeleteRefreshTokenCommand>
{
    private readonly ArticlesAggregatorDbContext _dbContext;

    public DeleteRefreshTokenCommandHandler(ArticlesAggregatorDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(DeleteRefreshTokenCommand command, CancellationToken cancellationToken)
    {
        var tokenToRemove = await _dbContext.RefreshTokens.FirstOrDefaultAsync(token =>
            token.Id.Equals(command.Id), cancellationToken)
            ?? throw new NotFoundException("Token", command.Id);

        _dbContext.RefreshTokens.Remove(tokenToRemove);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
