using ArticleAggregator.Data.Entities;

namespace ArticleAggregator_Repositories.Interfaces;

public interface ISourceCategoryRepository : IRepository<SourceCategory>
{
    Task<IEnumerable<SourceCategory>> GetSourcesWithNoCategory();
}
