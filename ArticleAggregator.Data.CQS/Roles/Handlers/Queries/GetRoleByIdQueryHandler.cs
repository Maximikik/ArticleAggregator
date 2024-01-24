using ArticleAggregator.Data.CQS.Roles.Queries;
using ArticleAggregator.Data.CustomExceptions;
using ArticleAggregator.Data.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArticleAggregator.Data.CQS.Roles.Handlers.Queries;

public class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQuery, Role>
{
    private readonly ArticlesAggregatorDbContext _dbContext;

    public GetRoleByIdQueryHandler(ArticlesAggregatorDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Role> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
    {
        return await _dbContext.Roles.FirstOrDefaultAsync(role => role.Id.Equals(request.Id), cancellationToken)
            ?? throw new NotFoundException("Role", request.Id);
    }
}
