using ArticleAggregator.Core.Dto;
using ArticleAggregator.Core.Models;

namespace ArticleAggregator.Services.Interfaces;

public interface IArticleService
{
    public Task InsertArticlesFromRssByArticleSourceId(Guid sourceId);

    public Task<IEnumerable<ArticleModel>> GetAll();
    public Task<ArticleModel?> GetArticleById(Guid id);
    public Task<IEnumerable<ArticleModel>> GetPositiveArticles(int rateGreaterThan = 5);

    public Task CreateArticle(ArticleDto dto);
    public Task CreateArticleAndSource(ArticleDto articleDto, SourceDto? sourceDto);

    public Task UpdateArticleDescription(Dictionary<Guid, string> ArticlesData);

    public Task DeleteArticle(Guid id);

    public Task<int> RateText(string text);
}
