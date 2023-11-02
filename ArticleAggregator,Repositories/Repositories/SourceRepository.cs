using ArticleAggregator.Data;
using ArticleAggregator.Data.Entities;
using ArticleAggregator_Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ArticleAggregator_Repositories.Repositories;

public class SourceRepository : Repository<Source>, ISourceRepository
{
    public SourceRepository(ArticlesAggregatorDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Source?> GetByUrl(string url)
    {
        return await _dbSet.FirstOrDefaultAsync(source => source.Url.Equals(url));
    }
}