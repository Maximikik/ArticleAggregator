using ArticleAggregator.Data;
using ArticleAggregator.Data.Entities;
using ArticleAggregator_Repositories.Interfaces;

namespace ArticleAggregator_Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ArticlesAggregatorDbContext _dbContext;

    private readonly IArticleRepository _articleRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IClientRepository _clientRepository;
    private readonly ISourceRepository _sourceRepository;
    private readonly ICommentRepository _commentRepository;
    private readonly IRoleRepository _roleRepository;

    public IArticleRepository ArticleRepository => _articleRepository;

    public ICategoryRepository CategoryRepository => _categoryRepository;

    public IClientRepository ClientRepository => _clientRepository;

    public ISourceRepository SourceRepository => _sourceRepository;

    public ICommentRepository CommentRepository => _commentRepository;

    public IRoleRepository RoleRepository => _roleRepository;

    public UnitOfWork(ArticlesAggregatorDbContext dbContext,
        IArticleRepository articleRepository, ICategoryRepository categoryRepository,
        IClientRepository clientRepository, ISourceRepository sourceRepository,
        ICommentRepository commentRepository, IRoleRepository repository)
    {
        _dbContext = dbContext;
        _articleRepository = articleRepository;
        _categoryRepository = categoryRepository;
        _clientRepository = clientRepository;
        _sourceRepository = sourceRepository;
        _commentRepository = commentRepository;
        _roleRepository = repository;
    }

    public async Task<int> Commit()
    {
        return await _dbContext.SaveChangesAsync();
    }
}
