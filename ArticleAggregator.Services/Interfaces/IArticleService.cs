using ArticleAggregator.Core.Dto;

namespace ArticleAggregator.Services.Interfaces;

public interface IArticleService
{
    public Task InsertArticlesFromRssByArticleSourceId(Guid sourceId);

    public Task<ArticleDto[]?> GetAll();
    public Task<ArticleDto?> GetArticleById(Guid id);
    public Task<ArticleDto?> GetArticleByTitle(string name);
    public Task<ArticleDto[]?> GetPositiveArticles(int rateGreaterThan = 5);
    public Task<CommentDto[]?> GetCommentsOfArticle(Guid id);

    public Task<Guid> CreateArticle(ArticleDto dto);
    public Task CreateArticleAndSource(ArticleDto articleDto, SourceDto? sourceDto);

    public Task UpdateArticleDescription(Dictionary<Guid, string> ArticlesData);
    
    public Task DeleteArticle(Guid id);

    public Task<int> RateText(string text);
}
