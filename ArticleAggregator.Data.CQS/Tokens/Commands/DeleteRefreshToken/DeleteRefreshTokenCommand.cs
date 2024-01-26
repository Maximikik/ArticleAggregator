using MediatR;

namespace ArticleAggregator.Data.CQS.Tokens.Commands.DeleteRefreshToken;

public class DeleteRefreshTokenCommand : IRequest
{
    public Guid Id { get; set; }
}
