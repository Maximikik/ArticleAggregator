using ArticleAggregator.Data.CQS.Articles.Commands;
using ArticleAggregator.Data.CQS.CustomExceptions;
using ArticleAggregator.Mapping;
using MediatR;

namespace ArticleAggregator.Data.CQS.Articles.Handlers.Commands;

public class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommand>
{
    private readonly ArticlesAggregatorDbContext _dbContext;
    private readonly ArticleMapper _mapper;

    public CreateArticleCommandHandler(ArticlesAggregatorDbContext dbContext,
        ArticleMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    public async Task Handle(CreateArticleCommand request, CancellationToken cancellationToken)
    {
        _ = request.ArticleDto ?? throw new NotFoundException("ArticleDto");

        var article = _mapper.ArticleDtoToArticle(request.ArticleDto);
        await _dbContext.Articles.AddAsync(article, cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
