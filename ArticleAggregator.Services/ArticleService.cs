using ArticleAggregator.Core.Dto;
using ArticleAggregator.Data.CQS.Articles.Commands.CreateArticle;
using ArticleAggregator.Data.CQS.Articles.Commands.DeleteArticleById;
using ArticleAggregator.Data.CQS.Articles.Commands.InsertRssData;
using ArticleAggregator.Data.CQS.Articles.Commands.UpdateArticleText;
using ArticleAggregator.Data.CQS.Articles.Queries.GetArticleById;
using ArticleAggregator.Data.CQS.Articles.Queries.GetArticleByName;
using ArticleAggregator.Data.CQS.Articles.Queries.GetCommentsOfArticle;
using ArticleAggregator.Data.CQS.Articles.Queries.GetPositive;
using ArticleAggregator.Data.CQS.Categories.Commands.CreateCategory;
using ArticleAggregator.Data.CQS.Categories.Queries.GetCategoryByName;
using ArticleAggregator.Data.CustomExceptions;
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
    private readonly CommentMapper _commentMapper;
    private readonly IMediator _mediator;
    private readonly IConfiguration _configuration;

    public ArticleService(IUnitOfWork unitOfWork,
       ArticleMapper articleMapper, CommentMapper commentMapper, IMediator mediator, IConfiguration configuration)
    {
        _unitOfWork = unitOfWork;
        _articleMapper = articleMapper;
        _commentMapper = commentMapper;
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

            feed.Categories.Select(async item => await _mediator.Send(new CreateCategoryCommand
            {
                CategoryDto = new CategoryDto
                {
                    Id = Guid.NewGuid(),
                    Name = item.Name,
                    PositivityRating = 1
                }
            }));

            var categoriesId = new List<Guid>();

            foreach (var category in feed.Categories)
            {
                categoriesId.Add((await _mediator.Send(new GetCategoryByNameQuery { Name = category.Name })).Id);
            }

            var rssArticles = feed.Items.Select(item => new ArticleDto()
            {
                Id = Guid.NewGuid(),
                ArticleSourceId = sourceId,
                Title = item.Title.Text,
                Rating = 0,
                Description = item.Summary.Text,
                CategoriesId = categoriesId,
                SourceUrl = articleSourceRss,
            }).ToArray();

            return rssArticles;
        }
    }

    public async Task InsertArticlesFromRssByArticleSourceId(Guid sourceId)
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

    public async Task<ArticleDto[]?> GetAll()
    {
        var request = new GetPositiveArticlesQuery { rateGreaterThan = 0 };

        var articles = await _mediator.Send(request);

        var articlesDto = articles.Select(article => _articleMapper.ArticleToArticleDto(article)).ToArray();

        return articlesDto;
    }

    private async Task<string[]> GetExistedArticlesUrls()
    {
        var existedArticlesUrls = await _unitOfWork.ArticleRepository.GetAsQueryable()
            .Select(article => article.ArticleSource.Url).ToArrayAsync();
        return existedArticlesUrls;
    }

    public async Task<Guid> CreateArticle(ArticleDto dto)
    {
        var command = new CreateArticleCommand() { ArticleDto = dto };
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
        var command = new DeleteArticleByIdCommand { ArticleId = id };
        await _mediator.Send(command);
    }

    public async Task<ArticleDto?> GetArticleById(Guid id)
    {
        var articleDto = _articleMapper.ArticleToArticleDto(
                await _mediator.Send(new GetArticleByIdQuery { Id = id }));

        return articleDto;
    }

    public async Task<ArticleDto?> GetArticleByTitle(string name)
    {
        var request = new GetArticleByTitleQuery { ArticleTitle = name };
        var article = await _mediator.Send(request);

        return _articleMapper.ArticleToArticleDto(article);
    }

    public async Task<ArticleDto[]?> GetPositiveArticles(int rateGreaterThan = 5)
    {
        var request = new GetPositiveArticlesQuery { rateGreaterThan = rateGreaterThan };

        var articles = await _mediator.Send(request);

        var articlesDto = articles.Select(article => _articleMapper.ArticleToArticleDto(article)).ToArray();

        return articlesDto;
    }

    public async Task<CommentDto[]?> GetCommentsOfArticle(Guid id)
    {
        var article = await _unitOfWork.ArticleRepository.GetById(id)
            ?? throw new NotFoundException("Article", id);

        var request = new GetCommentsOfArticleQuery { Id = id };
        var comments = await _mediator.Send(request);

        var commentsDto = comments.Select(comment => _commentMapper.CommentToCommentDto(comment)).ToArray();

        return commentsDto;
    }

    public async Task UpdateArticleDescription(Dictionary<Guid, string> ArticlesData)
    {
        var command = new UpdateArticleTextCommand { ArticlesData = ArticlesData };
        await _mediator.Send(command);
    }

    public async Task<int> RateText(string text)
    {
        return await _unitOfWork.ArticleRepository.RateTextForPositivity(text);
    }
}
