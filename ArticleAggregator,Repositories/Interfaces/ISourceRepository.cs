using ArticleAggregator.Data.Entities;

namespace ArticleAggregator_Repositories.Interfaces;

public interface ISourceRepository : IRepository<Source>
{
    Task<Source?> GetByUrl(string url);
}
