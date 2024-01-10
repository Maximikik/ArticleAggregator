using MediatR;
using ArticleAggregator.Data.Entities;

namespace ArticleAggregator.Data.CQS.Queries;

public class GetRefreshTokenQuery : IRequest<RefreshToken>
{
    public Guid Id { get; set; }
}