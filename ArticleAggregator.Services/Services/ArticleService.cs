using ArticleAggregator.Core.Dto;
using ArticleAggregator.Core.Models;
using ArticleAggregator.Data.CQS.Articles.Commands.CreateArticle;
using ArticleAggregator.Data.CQS.Articles.Commands.DeleteArticleById;
using ArticleAggregator.Data.CQS.Articles.Commands.InsertRssData;
using ArticleAggregator.Data.CQS.Articles.Commands.UpdateArticleText;
using ArticleAggregator.Data.CQS.Articles.Queries.GetArticleById;
using ArticleAggregator.Data.CQS.Articles.Queries.GetPositive;
using ArticleAggregator.Data.CQS.Categories.Commands.CreateCategory;
using ArticleAggregator.Data.CQS.Categories.Queries.GetCategoryByName;
using ArticleAggregator.Mapping;
using ArticleAggregator.Services.Interfaces;
using ArticleAggregator_Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.ServiceModel.Syndication;
using System.Xml;

namespace ArticleAggregator.Services.Services;

public class ArticleService(IUnitOfWork _unitOfWork,
    IMapper _mapper,
    IMediator _mediator, IConfiguration _configuration
    ) : IArticleService
{
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

        var uniqueArticles = data!
            .Where(dto => !existedArticles
                .Any(url => dto.SourceUrl.Equals(url))).ToArray();

        var command = new InsertRssDataCommand()
        {
            Articles = uniqueArticles
        };
        await _mediator.Send(command);
    }

    public async Task<IEnumerable<ArticleModel>> GetAll()
    {
        return await _mediator.Send(new GetPositiveArticlesQuery { rateGreaterThan = 0 });
    }

    private async Task<string[]> GetExistedArticlesUrls()
    {
        var existedArticlesUrls = await _unitOfWork.ArticleRepository.GetAsQueryable()
            .Select(article => article.ArticleSource.Url).ToArrayAsync();
        return existedArticlesUrls;
    }

    public async Task CreateArticle(ArticleDto dto)
    {
        await _mediator.Send(new CreateArticleCommand() { ArticleDto = dto });
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

    public async Task<ArticleModel?> GetArticleById(Guid id)
    {
        return await _mediator.Send(new GetArticleByIdQuery { Id = id });
    }

    public async Task<IEnumerable<ArticleModel>> GetPositiveArticles(int rateGreaterThan = 5)
    {
        return await _mediator.Send(new GetPositiveArticlesQuery { rateGreaterThan = rateGreaterThan });
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
