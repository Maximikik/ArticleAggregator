using ArticleAggregator.Core;
using ArticleAggregator.Data.CQS.Articles.Commands;
using ArticleAggregator.Data.CQS.Articles.Queries;
using ArticleAggregator.Mapping;
using ArticleAggregator.Services.Interfaces;
using ArticleAggregator_Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.ServiceModel.Syndication;
using System.Xml;

namespace ArticleAggregator.Services;

public class ArticleService : IArticleService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ArticleMapper _articleMapper;
    private readonly IMediator _mediator;
    private readonly IConfiguration _configuration;

    public ArticleService(IUnitOfWork unitOfWork,
       ArticleMapper articleMapper, IMediator mediator, IConfiguration configuration)
    {
        _unitOfWork = unitOfWork;
        _articleMapper = articleMapper;
        _mediator = mediator;
        _configuration = configuration;
    }

    public async Task<ArticleDto[]?> AggregateDataFromRssByArticleSourceId(Guid sourceId)
    {
        var articleSourceRss = (await _unitOfWork.SourceRepository.GetById(sourceId))?.RssUrl;
        if (string.IsNullOrWhiteSpace(articleSourceRss)) return null;
        using (var reader = XmlReader.Create(articleSourceRss))
        {
            var feed = SyndicationFeed.Load(reader);
            var rssArticles = feed.Items.Select(item => new ArticleDto()
            {
                Id = Guid.NewGuid(),
                ArticleSourceId = sourceId,
                Title = item.Title.Text,
            }).ToArray();
            return rssArticles;
        }
    }

    public async Task AggregateArticlesFromRssByArticleSourceId(Guid sourceId)
    {
        var data = await AggregateDataFromRssByArticleSourceId(sourceId);

        var existedArticles = await GetExistedArticlesUrls();

        var uniqueArticles = data
            .Where(dto => !existedArticles
                .Any(url => dto.SourceUrl.Equals(url))).ToArray();

        var command = new InsertRssDataCommand()
        {
            Articles = uniqueArticles
        };
        await _mediator.Send(command);
    }

    private async Task<string[]> GetExistedArticlesUrls()
    {
        var existedArticlesUrls = await _unitOfWork.ArticleRepository.GetAsQueryable()
            .Select(article => article.ArticleSource.Url).ToArrayAsync();
        return existedArticlesUrls;
    }

    public async Task<Guid> CreateArticle(ArticleDto dto)
    {
        var command = new CreateArticleCommand() { ArticleDto = dto};
        var id = command.ArticleDto.Id;
        await _mediator.Send(command);
        return id;
    }

    public Task CreateArticleAndSource(ArticleDto articleDto, SourceDto? sourceDto)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteArticle(Guid id)
    {
        await _unitOfWork.ArticleRepository.DeleteById(id);
        await _unitOfWork.Commit();
    }

    public async Task<ArticleDto?> GetArticleById(Guid id)
    {
        var articleDto = _articleMapper.ArticleToArticleDto(
                await _mediator.Send(new GetArticleByIdQuery { Id = id }));

        return articleDto;
    }

    public async Task<ArticleDto[]?> GetArticlesByName(string name)
    {
        var articles = await _unitOfWork.ArticleRepository
                .FindBy(article => EF.Functions.Like(article.Title, $"%{name}"))
                .Select(article => _articleMapper.ArticleToArticleDto(article))
                .ToArrayAsync();
        return articles;
    }

    public async Task<ArticleDto[]?> GetPositive()
    {
        var articles = await _unitOfWork.ArticleRepository
                .GetAsQueryable()
                //.FindBy(article => article.Rate>=0)
                .Select(article => _articleMapper.ArticleToArticleDto(article))
                .ToArrayAsync();
        return articles;
    }

    public Task<CommentDto[]?> GetCommentsOfArticle(Guid id)
    {
        throw new NotImplementedException();
    }
}
