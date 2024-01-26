using MediatR;

namespace ArticleAggregator.Data.CQS.Tokens.Commands.AddRefreshToken;

public class AddRefreshTokenCommand : IRequest<Guid>
{
    public Guid ClientId { get; set; }
    public string Ip { get; set; } = null!;
}
