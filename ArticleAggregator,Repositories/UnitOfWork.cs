using ArticleAggregator.Data;
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
    private readonly IFeedRepository _feedRepository;

    public IArticleRepository ArticleRepository => _articleRepository;

    public ICategoryRepository CategoryRepository => _categoryRepository;

    public IClientRepository ClientRepository => _clientRepository;

    public ISourceRepository SourceRepository => _sourceRepository;

    public ICommentRepository CommentRepository => _commentRepository;

    public IRoleRepository RoleRepository => _roleRepository;

    public IFeedRepository FeedRepository => _feedRepository;

    public UnitOfWork(ArticlesAggregatorDbContext dbContext,
        IArticleRepository articleRepository, ICategoryRepository categoryRepository,
        IClientRepository clientRepository, ISourceRepository sourceRepository,
        ICommentRepository commentRepository, IRoleRepository repository,
        IFeedRepository feedRepository)
    {
        _dbContext = dbContext;
        _articleRepository = articleRepository;
        _categoryRepository = categoryRepository;
        _clientRepository = clientRepository;
        _sourceRepository = sourceRepository;
        _commentRepository = commentRepository;
        _roleRepository = repository;
        _feedRepository = feedRepository;
    }

    public async Task<int> Commit()
    {
        return await _dbContext.SaveChangesAsync();
    }
}
