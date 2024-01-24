using ArticleAggregator.Data.CQS.Roles.Commands;
using ArticleAggregator.Data.CustomExceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArticleAggregator.Data.CQS.Roles.Handlers.Commands;

public class DeleteRoleByNameCommandHandler : IRequestHandler<DeleteRoleByNameCommand>
{
    private readonly ArticlesAggregatorDbContext _dbContext;

    public DeleteRoleByNameCommandHandler(ArticlesAggregatorDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(DeleteRoleByNameCommand request, CancellationToken cancellationToken)
    {
        var role = await _dbContext.Roles.FirstOrDefaultAsync(role => role.Name.Equals(request.Name), cancellationToken)
            ?? throw new NotFoundException("Role", request.Name);

        _dbContext.Roles.Remove(role);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
