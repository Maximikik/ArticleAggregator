using ArticleAggregator.Data.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArticleAggregator.Data.CQS.Roles.Queries.GetAllRoles;

public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, List<Role>>
{
    private readonly ArticlesAggregatorDbContext _dbContext;

    public GetAllRolesQueryHandler(ArticlesAggregatorDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Role>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
    {
        return await _dbContext.Roles.ToListAsync();
    }
}