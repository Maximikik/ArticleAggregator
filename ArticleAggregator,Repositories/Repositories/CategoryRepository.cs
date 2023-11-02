using ArticleAggregator.Core;
using ArticleAggregator.Data;
using ArticleAggregator.Data.Entities;
using ArticleAggregator_Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ArticleAggregator_Repositories.Repositories;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(ArticlesAggregatorDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Category> GetByName(string name)
    {
        return await _dbSet.FirstOrDefaultAsync(article => article.Name.Equals(name));
    }
}
