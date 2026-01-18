using ArticleAggregator.Core.Dto;
using ArticleAggregator.Data.CustomExceptions;
using ArticleAggregator.Data.Entities;
using ArticleAggregator.Mapping;
using MediatR;

namespace ArticleAggregator.Data.CQS.Sources.Commands.CreateSource;

public class CreateSourceCommandHandler(ArticlesAggregatorDbContext _dbContext, IMapper mapper) : IRequestHandler<CreateSourceCommand>
{
    public async Task Handle(CreateSourceCommand request, CancellationToken cancellationToken)
    {
        _ = request.SourceDto ?? throw new NotFoundException("Source");

        var source = mapper.Map<SourceDto, Source>(request.SourceDto);

        var articles = _dbContext.Articles.Where(article => request.SourceDto.ArticlesId.Contains(article.Id)).ToList();

        source.Articles = articles;

        await _dbContext.Sources.AddAsync(source, cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}