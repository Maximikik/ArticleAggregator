using ArticleAggregator.Data.CQS.Roles.Queries;
using ArticleAggregator.Data.CustomExceptions;
using ArticleAggregator.Data.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArticleAggregator.Data.CQS.Roles.Handlers.Queries;

public class GetRoleByNameQueryHandler : IRequestHandler<GetRoleByNameQuery, Role>
{
    private readonly ArticlesAggregatorDbContext _dbContext;

    public GetRoleByNameQueryHandler(ArticlesAggregatorDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Role> Handle(GetRoleByNameQuery request, CancellationToken cancellationToken)
    {
        return await _dbContext.Roles.FirstOrDefaultAsync(role => role.Name.Equals(request.Name), cancellationToken)
            ?? throw new NotFoundException("Role", request.Name);
    }
}
