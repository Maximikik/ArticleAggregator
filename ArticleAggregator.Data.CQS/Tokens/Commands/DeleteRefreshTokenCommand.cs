using MediatR;

namespace ArticleAggregator.Data.CQS.Tokens.Commands;

public class DeleteRefreshTokenCommand : IRequest
{
    public Guid Id { get; set; }
}
