using ArticleAggregator.Data;
using ArticleAggregator.Data.Entities;
using ArticleAggregator_Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ArticleAggregator_Repositories.Repositories;

public class ClientRepository : Repository<Client>, IClientRepository
{
    public ClientRepository(ArticlesAggregatorDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Client> GetByLogin(string name)
    {
        return await _dbSet.FirstOrDefaultAsync(article => article.Login.Equals(name));
    }
}
