using ArticleAggregator.Data.Entities;

namespace ArticleAggregator_Repositories.Interfaces;

public interface ISourceCategoriesRepository : IRepository<SourceCategories>
{
    Task<IQueryable<SourceCategories>> GetSourcesWithNoCategory();
}
