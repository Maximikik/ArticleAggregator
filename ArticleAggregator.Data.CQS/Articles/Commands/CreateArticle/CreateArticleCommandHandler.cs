using ArticleAggregator.Data.CustomExceptions;
using ArticleAggregator.Mapping;
using MediatR;

namespace ArticleAggregator.Data.CQS.Articles.Commands.CreateArticle;

public class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommand>
{
    private readonly ArticlesAggregatorDbContext _dbContext;
    private readonly ArticleMapper _articleMapper;

    public CreateArticleCommandHandler(ArticlesAggregatorDbContext dbContext,
        ArticleMapper articleMapper)
    {
        _dbContext = dbContext;
        _articleMapper = articleMapper;
    }
    public async Task Handle(CreateArticleCommand request, CancellationToken cancellationToken)
    {
        _ = request.ArticleDto ?? throw new NotFoundException("ArticleDto");

        var article = _articleMapper.ArticleDtoToArticle(request.ArticleDto);

        var categories = _dbContext.Categories.Where(c => request.ArticleDto.CategoriesId.Contains(c.Id)).ToList();

        article.Categories = categories;

        await _dbContext.Articles.AddAsync(article, cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
