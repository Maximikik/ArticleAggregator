using ArticleAggregator_Repositories.Interfaces;

namespace ArticleAggregator_Repositories;

public interface IUnitOfWork
{
    public IArticleRepository ArticleRepository { get; }

    public ICategoryRepository CategoryRepository { get; }

    public IClientRepository ClientRepository { get; }

    public ISourceRepository SourceRepository { get; }

    public ICommentRepository CommentRepository { get; }

    public IRoleRepository RoleRepository { get; }

    Task<int> Commit();
}
