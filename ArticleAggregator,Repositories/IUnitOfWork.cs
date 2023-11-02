namespace ArticleAggregator_Repositories;

public interface IUnitOfWork
{
    IRepository<Article> ArticleRepository { get; }
    IRepository<Source> ArticleSourceRepository { get; }

    Task<int> Commit();
}
