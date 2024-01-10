using ArticleAggregator.Data.CQS.Comments.Commands;
using ArticleAggregator.Data.CQS.CustomExceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArticleAggregator.Data.CQS.Comments.Handlers.Commands;

public class RemoveCommentFromArticleCommandHandler : IRequestHandler<RemoveCommentFromArticleCommand>
{
    private readonly ArticlesAggregatorDbContext _dbContext;

    public RemoveCommentFromArticleCommandHandler(ArticlesAggregatorDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(RemoveCommentFromArticleCommand request, CancellationToken cancellationToken)
    {
        var comment = await _dbContext.Comments.FirstOrDefaultAsync(comment => comment.Id.Equals(request.CommentId))
            ?? throw new NotFoundException("Comment", request.CommentId);

        _dbContext.Comments.Remove(comment);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
