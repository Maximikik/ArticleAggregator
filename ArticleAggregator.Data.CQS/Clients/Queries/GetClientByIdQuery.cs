using ArticleAggregator.Data.Entities;
using MediatR;

namespace ArticleAggregator.Data.CQS.Clients.Queries;

public class GetClientByIdQuery : IRequest<Client>
{
    public Guid Id { get; set; }
}
