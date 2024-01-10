using MediatR;

namespace ArticleAggregator.Data.CQS.Tokens.Commands;

public class AddRefreshTokenCommand : IRequest<Guid>
{
    public Guid ClientId { get; set; }
    public string Ip { get; set; } = null!;
}
