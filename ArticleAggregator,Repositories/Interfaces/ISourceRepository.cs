using ArticleAggregator.Data.Entities;

namespace ArticleAggregator_Repositories.Interfaces;

public interface ISourceRepository
{
    Task<Source?> GetByUrl(string url);
}
