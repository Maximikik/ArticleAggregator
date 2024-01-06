using ArticleAggregator.Data.Entities;
using ArticleAggregator_Repositories.Interfaces;

namespace ArticleAggregator_Repositories;

public interface IUnitOfWork
{
    IRepository<Article> ArticleRepository { get; }
    IRepository<Category> CategoryRepository { get; }
    IRepository<Client> ClientRepository { get; }
    IRepository<Comment> CommentRepository { get; }
    IRepository<Source> SourceRepository { get; }
    IRepository<Role> RoleRepository { get; }

    Task<int> Commit();
}
