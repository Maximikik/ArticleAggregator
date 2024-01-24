using ArticleAggregator.Data.CQS.Sources.Commands;
using ArticleAggregator.Data.CustomExceptions;
using ArticleAggregator.Mapping;
using MediatR;

namespace ArticleAggregator.Data.CQS.Sources.Handlers.Commands;

public class CreateSourceCommandHandler : IRequestHandler<CreateSourceCommand>
{
    private readonly ArticlesAggregatorDbContext _dbContext;
    private readonly SourceMapper _sourceMapper;

    public CreateSourceCommandHandler(ArticlesAggregatorDbContext dbContext, SourceMapper sourceMapper)
    {
        _dbContext = dbContext;
        _sourceMapper = sourceMapper;
    }

    public async Task Handle(CreateSourceCommand request, CancellationToken cancellationToken)
    {
        _ = request.SourceDto ?? throw new NotFoundException("Source");

        var source = _sourceMapper.SourceDtoToSource(request.SourceDto);

        var articles = _dbContext.Articles.Where(article => request.SourceDto.ArticlesId.Contains(article.Id)).ToList();

        source.Articles = articles;

        await _dbContext.Sources.AddAsync(source, cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}