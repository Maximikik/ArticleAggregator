using ArticleAggregator.Data.Entities;
using MediatR;

namespace ArticleAggregator.Data.CQS.Tokens.Queries.GetRefreshToken;

public class GetRefreshTokenQuery : IRequest<RefreshToken>
{
    public Guid Id { get; set; }
}