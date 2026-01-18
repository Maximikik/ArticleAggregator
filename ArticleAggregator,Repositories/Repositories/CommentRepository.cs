using ArticleAggregator.Data;
using ArticleAggregator.Data.CustomExceptions;
using ArticleAggregator.Data.Entities;
using ArticleAggregator_Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

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

    public async Task<List<Comment>> GetArticleComments(Article article)
    {
        var comments = _dbSet.Where(comment => comment.ArticleId.Equals(article.Id))
            ?? throw new NotFoundException("Article", article.Id);

        return await comments.ToListAsync();
    }
}