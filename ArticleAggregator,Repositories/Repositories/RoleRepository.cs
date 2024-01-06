using ArticleAggregator.Data;
using ArticleAggregator.Data.Entities;
using ArticleAggregator_Repositories.Interfaces;

namespace ArticleAggregator_Repositories.Repositories;

public class RoleRepository : Repository<Role>, IRoleRepository
{
    private readonly ArticlesAggregatorDbContext _dbContext;

    public RoleRepository(ArticlesAggregatorDbContext dbContext)
        : base(dbContext)
    {
    }
}
