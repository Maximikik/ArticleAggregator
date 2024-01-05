using ArticleAggregator.Data.CQS.Roles.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArticleAggregator.Data.CQS.Roles.Handlers.Commands;

public class DeleteRoleByIdCommandHandler : IRequestHandler<DeleteRoleByIdCommand>
{
    private readonly ArticlesAggregatorDbContext _dbContext;

    public DeleteRoleByIdCommandHandler(ArticlesAggregatorDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(DeleteRoleByIdCommand request, CancellationToken cancellationToken)
    {
        var role = await _dbContext.Roles.FirstOrDefaultAsync(role => role.Id.Equals(request.Id),cancellationToken)
            ?? throw new Exception();

        _dbContext.Roles.Remove(role);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
