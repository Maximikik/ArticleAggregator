using ArticleAggregator.Data.Entities;
using MediatR;

namespace ArticleAggregator.Data.CQS.Clients.Queries.GetClientByLogin;

public class GetClientByLoginQuery : IRequest<Client>
{
    public string Login { get; set; } = null!;
}
