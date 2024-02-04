using ArticleAggregator.Data.Entities;
using MediatR;

namespace ArticleAggregator.Data.CQS.Clients.Queries.GetClientByRefreshToken;

public class GetClientByRefreshTokenQuery : IRequest<Client>
{
    public Guid RefreshTokenId { get; set; }
}