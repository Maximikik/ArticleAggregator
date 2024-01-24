using ArticleAggregator.Core.Dto;
using MediatR;

namespace ArticleAggregator.Data.CQS.Roles.Commands;

public class CreateRoleCommand : IRequest
{
    public RoleDto RoleDto { get; set; }
}
