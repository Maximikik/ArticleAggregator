using ArticleAggregator.Data.CustomExceptions;
using ArticleAggregator.Data.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArticleAggregator.Data.CQS.Articles.Queries.GetCommentsOfArticle;

public class GetCommentsOfArticleCommandHandler : IRequestHandler<GetCommentsOfArticleCommand, List<Comment>>
{
    private readonly ArticlesAggregatorDbContext _dbContext;
    public GetCommentsOfArticleCommandHandler(ArticlesAggregatorDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<List<Comment>> Handle(GetCommentsOfArticleCommand request, CancellationToken cancellationToken)
    {
        var article = await _dbContext.Articles.FirstOrDefaultAsync(article => article.Id.Equals(request.Id))
            ?? throw new NotFoundException("Article", request.Id); // TODO FIX

        var comments = _dbContext.Comments.Where(comment => comment.ArticleId.Equals(article.Id)).ToList();
        return comments ??= new List<Comment>();
    }
}