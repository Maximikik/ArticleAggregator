using ArticleAggregator.Data.CQS.Roles.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArticleAggregator.Data.CQS.Roles.Handlers.Commands;

public class UpdateRoleByIdCommandHandler : IRequestHandler<UpdateRoleByIdCommand>
{
    private readonly ArticlesAggregatorDbContext _dbContext;

    public UpdateRoleByIdCommandHandler(ArticlesAggregatorDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(UpdateRoleByIdCommand request, CancellationToken cancellationToken)
    {
        var role = await _dbContext.Roles.FirstOrDefaultAsync(role => role.Id.Equals(request.Id), cancellationToken)
            ?? throw new Exception();

        role.Name = request.Name;
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
