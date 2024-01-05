using ArticleAggregator.Core;
using MediatR;

namespace ArticleAggregator.Data.CQS.Roles.Commands;

public class CreateRoleCommand : IRequest
{
    public RoleDto RoleDto { get; set; }
}
