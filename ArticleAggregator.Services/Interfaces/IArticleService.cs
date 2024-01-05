using ArticleAggregator.Core;

namespace ArticleAggregator.Services.Interfaces;

public interface IArticleService
{
    public Task AggregateArticlesFromRssByArticleSourceId(Guid sourceId);

    public Task<ArticleDto?> GetArticleById(Guid id);
    public Task<ArticleDto[]?> GetArticlesByName(string name);
    public Task<ArticleDto[]?> GetPositive();
    public Task<CommentDto[]?> GetCommentsOfArticle(Guid id);
    public Task DeleteArticle(Guid id);

    public Task<Guid> CreateArticle(ArticleDto dto);
    public Task CreateArticleAndSource(ArticleDto articleDto, SourceDto? sourceDto);
}
