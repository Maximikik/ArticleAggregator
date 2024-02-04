using ArticleAggregator.Data.Entities;
using MediatR;

namespace ArticleAggregator.Data.CQS.Clients.Queries.GetClientByRole;

public class GetClientsByRoleQuery : IRequest<List<Client>>
{
    public string roleName { get; set; } = null!;
}
