using MediatR;

namespace ArticleAggregator.Data.CQS.Roles.Commands;

public class UpdateRoleByIdCommand : IRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
}
