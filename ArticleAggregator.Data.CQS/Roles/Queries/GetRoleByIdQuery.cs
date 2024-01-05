using ArticleAggregator.Data.Entities;
using MediatR;

namespace ArticleAggregator.Data.CQS.Roles.Queries;

public class GetRoleByIdQuery : IRequest<Role>
{
    public Guid Id { get; set; }
}
