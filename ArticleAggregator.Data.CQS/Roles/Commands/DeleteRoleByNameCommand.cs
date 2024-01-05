using MediatR;

namespace ArticleAggregator.Data.CQS.Roles.Commands;

public class DeleteRoleByNameCommand : IRequest
{
    public string Name { get; set; } = null!;
}
