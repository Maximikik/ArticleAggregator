using ArticleAggregator.Data;
using ArticleAggregator.Data.Entities;
using ArticleAggregator_Repositories.Interfaces;

namespace ArticleAggregator_Repositories.Repositories;

public class CommentRepository : Repository<Comment>, ICommentRepository
{
    private readonly ArticlesAggregatorDbContext _dbContext;

    public CommentRepository(ArticlesAggregatorDbContext dbContext) 
        : base(dbContext)
    { 
    }

    public async Task AddCommentToArticle(Comment comment, Article article)
    {
        _ = comment ?? throw new Exception();
        _ = article ?? throw new Exception();

        comment.ArticleId = article.Id;
        await _dbContext.Comments.AddAsync(comment);
        await _dbContext.SaveChangesAsync();
    }
}