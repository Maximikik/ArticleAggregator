using ArticleAggregator.Data;
using ArticleAggregator.Data.Entities;
using ArticleAggregator_Repositories.Interfaces;

namespace ArticleAggregator_Repositories;

public class UnitOfWork : IUnitOfWork
{
    public UnitOfWork(ArticlesAggregatorDbContext dbContext,
        IRepository<Article> articleRepository, IRepository<Category> categoryRepository,
        IRepository<Client> clientRepository, IRepository<Source> sourceRepository)
    {
        _dbContext = dbContext;
        _articleRepository = articleRepository;
        _categoryRepository = categoryRepository;
        _clientRepository = clientRepository;
        _sourceRepository = sourceRepository;
    }

    private readonly ArticlesAggregatorDbContext _dbContext;

    private readonly IRepository<Article> _articleRepository;
    private readonly IRepository<Category> _categoryRepository;
    private readonly IRepository<Client> _clientRepository;
    private readonly IRepository<Source> _sourceRepository;

    public IRepository<Article> ArticleRepository => _articleRepository;

    public IRepository<Category> CategoryRepository => _categoryRepository;

    public IRepository<Client> ClientRepository => _clientRepository;

    public IRepository<Source> SourceRepository => _sourceRepository;


    public async Task<int> Commit()
    {
        return await _dbContext.SaveChangesAsync();
    }
}
