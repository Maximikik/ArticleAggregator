using ArticleAggregator.Data.Entities;
using MediatR;

namespace ArticleAggregator.Data.CQS.Queries;

public class GetRefreshTokenQuery : IRequest<RefreshToken>
{
    public Guid Id { get; set; }
}