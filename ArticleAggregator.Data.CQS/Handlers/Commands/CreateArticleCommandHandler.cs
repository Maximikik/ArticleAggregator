using ArticleAggregator.Data.CQS.Commands;
using ArticleAggregator.Mapping;
using MediatR;

namespace ArticleAggregator.Data.CQS.Handlers.Commands;

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
        var article = _mapper.ArticleDtoToArticle(request.ArticleDto);
        var entry = await _dbContext.Articles.AddAsync(article, cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
