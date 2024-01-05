using ArticleAggregator.Data.Entities;
using MediatR;

namespace ArticleAggregator.Data.CQS.Roles.Queries;

public class GetRoleByNameQuery : IRequest<Role>
{
    public string Name { get; set; } = null!;
}
