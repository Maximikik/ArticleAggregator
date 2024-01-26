using ArticleAggregator.Core.Dto;
using ArticleAggregator.Data.CQS.Categories.Commands.DeleteCategoryById;
using ArticleAggregator.Data.CQS.Sources.Commands.CreateSource;
using ArticleAggregator.Data.CQS.Sources.Queries.GetAllSources;
using ArticleAggregator.Data.CQS.Sources.Queries.GetArticlesOfSourceById;
using ArticleAggregator.Data.CQS.Sources.Queries.GetArticlesOfSourceByName;
using ArticleAggregator.Data.CQS.Sources.Queries.GetSourceById;
using ArticleAggregator.Data.CQS.Sources.Queries.GetSourceByName;
using ArticleAggregator.Mapping;
using ArticleAggregator.Services.Interfaces;
using ArticleAggregator_Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace ArticleAggregator.Services;

public class SourceService : ISourceService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly SourceMapper _sourceMapper;
    private readonly ArticleMapper _articleMapper;
    private readonly IMediator _mediator;
    private readonly IConfiguration _configuration;
    public SourceService(IUnitOfWork unitOfWork,
      SourceMapper sourceMapper, ArticleMapper articleMapper, IMediator mediator, IConfiguration configuration)
    {
        _unitOfWork = unitOfWork;
        _sourceMapper = sourceMapper;
        _articleMapper = articleMapper;
        _mediator = mediator;
        _configuration = configuration;
    }

    public async Task CreateSource(SourceDto soruceDto)
    {
        var command = new CreateSourceCommand() { SourceDto = soruceDto };

        await _mediator.Send(command);
    }

    public async Task DeleteSource(Guid id)
    {
        var command = new DeleteCategoryByIdCommand() { Id = id };
        await _mediator.Send(command);
    }

    public async Task<SourceDto[]?> GetAllSources()
    {
        var sources = await _mediator.Send(new GetAllSourcesQuery());

        var sourcesDto = new SourceDto[sources.Count()];

        sources.ForEach(source =>
        {
            sourcesDto[sources.IndexOf(source)] = _sourceMapper.SourceToSourceDto(source);
        });

        return sourcesDto;
    }

    public async Task<ArticleDto[]?> GetArticlesOfSourceById(Guid id)
    {
        var command = new GetArticlesOfSourceByIdQuery() { Id = id };

        var articles = await _mediator.Send(command);

        var articlesDto = new ArticleDto[articles.Count()];

        articles.ForEach(article =>
        {
            articlesDto[articles.IndexOf(article)] = _articleMapper.ArticleToArticleDto(article);
        });

        return articlesDto;
    }

    public async Task<ArticleDto[]?> GetArticlesOfSourceByName(string name)
    {
        var command = new GetArticlesOfSourceByNameQuery() { Name = name };

        var articles = await _mediator.Send(command);

        var articlesDto = new ArticleDto[articles.Count()];

        articles.ForEach(article =>
        {
            articlesDto[articles.IndexOf(article)] = _articleMapper.ArticleToArticleDto(article);
        });

        return articlesDto;
    }

    public async Task<SourceDto?> GetSourceById(Guid id)
    {
        var command = new GetSourceByIdQuery() { Id = id };

        var source = await _mediator.Send(command);
        var sourceDto = _sourceMapper.SourceToSourceDto(source);

        return sourceDto;
    }

    public async Task<SourceDto?> GetSourceByName(string name)
    {
        var command = new GetSourceByNameQuery() { Name = name };

        var source = await _mediator.Send(command);
        var sourceDto = _sourceMapper.SourceToSourceDto(source);

        return sourceDto;
    }
}
