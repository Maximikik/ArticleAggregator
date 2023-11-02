using ArticleAggregator.Data.Entities;

namespace ArticleAggregator_Repositories.Interfaces;

public interface ICategoryRepository : IRepository<Category>
{
    Task<Category> GetByName(string name);
}
