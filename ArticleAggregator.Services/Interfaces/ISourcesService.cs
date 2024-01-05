using ArticleAggregator.Core;

namespace ArticleAggregator.Services.Interfaces;

public interface ISourcesService
{
    public Task<SourceDto[]?> GetAllSources();
    public Task<SourceDto?> GetSourceById(Guid id);
    public Task<SourceDto[]?> GetSourceByName(string name);
    public Task<ArticleDto[]?> GetArticlesOfSourceById(Guid Id);
    public Task<ArticleDto[]?> GetArticlesOfSourceByName(string name);
    public Task DeleteSource(Guid id);

    public Task<Guid> CreateSource(SourceDto dto);
}
