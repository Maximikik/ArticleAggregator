using MediatR;

namespace ArticleAggregator.Data.CQS.Roles.Commands.DeleteRoleByName;

public class DeleteRoleByNameCommand : IRequest
{
    public string Name { get; set; } = null!;
}
