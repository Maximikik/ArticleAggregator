using ArticleAggregator.Data.Entities;
using MediatR;

namespace ArticleAggregator.Data.CQS.Clients.Queries.GetClientById;

public class GetClientByIdQuery : IRequest<Client>
{
    public Guid Id { get; set; }
}
