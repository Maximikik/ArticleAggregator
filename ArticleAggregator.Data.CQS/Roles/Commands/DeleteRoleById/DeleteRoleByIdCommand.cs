using MediatR;

namespace ArticleAggregator.Data.CQS.Roles.Commands.DeleteRoleById;

public class DeleteRoleByIdCommand : IRequest
{
    public Guid Id { get; set; }
}
