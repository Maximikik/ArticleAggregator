using ArticleAggregator.Core.Dto;
using ArticleAggregator.Data.CQS.Categories.Commands.DeleteCategoryById;
using ArticleAggregator.Data.CQS.Sources.Commands.CreateSource;
using ArticleAggregator.Data.CQS.Sources.Queries.GetAllSources;
using ArticleAggregator.Data.CQS.Sources.Queries.GetArticlesOfSourceById;
using ArticleAggregator.Data.CQS.Sources.Queries.GetArticlesOfSourceByName;
using ArticleAggregator.Data.CQS.Sources.Queries.GetSourceById;
using ArticleAggregator.Data.CQS.Sources.Queries.GetSourceByName;
using ArticleAggregator.Data.Entities;
using ArticleAggregator.Mapping;
using ArticleAggregator.Services.Interfaces;
using MediatR;

namespace ArticleAggregator.Services.Services;

public class SourceService(
    IMapper mapper,
    IMediator _mediator
    ) : ISourceService
{
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
            sourcesDto[sources.IndexOf(source)] = mapper.Map<Source, SourceDto>(source);
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
            articlesDto[articles.IndexOf(article)] = mapper.Map<Article, ArticleDto>(article);
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
            articlesDto[articles.IndexOf(article)] = mapper.Map<Article, ArticleDto>(article);
        });

        return articlesDto;
    }

    public async Task<SourceDto?> GetSourceById(Guid id)
    {
        var command = new GetSourceByIdQuery() { Id = id };

        var source = await _mediator.Send(command);
        var sourceDto = mapper.Map<Source, SourceDto>(source);

        return sourceDto;
    }

    public async Task<SourceDto?> GetSourceByName(string name)
    {
        var command = new GetSourceByNameQuery() { Name = name };

        var source = await _mediator.Send(command);
        var sourceDto = mapper.Map<Source, SourceDto>(source);

        return sourceDto;
    }
}
