using MediatR;

namespace ArticleAggregator.Data.CQS.Roles.Commands;

public class DeleteRoleByIdCommand : IRequest
{
    public Guid Id { get; set; }
}
