using ArticleAggregator.Core;
using ArticleAggregator.Data;
using ArticleAggregator.Data.Entities;
using ArticleAggregator_Repositories.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace ArticleAggregator_Repositories.Repositories;

public class SourceCategoriesRepository : Repository<SourceCategories>, ISourceCategoriesRepository
{
    public SourceCategoriesRepository(ArticlesAggregatorDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IQueryable<SourceCategories>> GetSourcesWithNoCategory()
    {
        return await Task.Run(() => _dbSet.Select(source => source).Where(source => source.Categories.IsNullOrEmpty()));
    }
}