using ArticleAggregator.Data.Entities;
using ArticleAggregator_Repositories.Interfaces;

namespace ArticleAggregator_Repositories;

public interface IUnitOfWork
{
    IRepository<Article> ArticleRepository { get; }
    IRepository<Category> ArticleSourceRepository { get; }
    IRepository<Client> ClientRepository { get; }
    IRepository<Source> SourceRepository { get; }
    IRepository<SourceCategories> SourceCategoriesRepository { get; }

    Task<int> Commit();
}
