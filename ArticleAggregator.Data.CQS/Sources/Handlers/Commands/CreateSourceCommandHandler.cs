using ArticleAggregator.Data.CQS.Sources.Commands;
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
        _ = request.SourceDto ?? throw new Exception();

        var source = _sourceMapper.SourceDtoToSource(request.SourceDto);

        await _dbContext.Sources.AddAsync(source, cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
