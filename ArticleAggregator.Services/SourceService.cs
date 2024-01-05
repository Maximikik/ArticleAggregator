using ArticleAggregator.Core;
using ArticleAggregator.Services.Interfaces;

namespace ArticleAggregator.Services;

public class SourceService : ISourcesService
{
    public Task<Guid> CreateSource(SourceDto dto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteSource(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<SourceDto[]?> GetAllSources()
    {
        throw new NotImplementedException();
    }

    public Task<ArticleDto[]?> GetArticlesOfSourceById(Guid Id)
    {
        throw new NotImplementedException();
    }

    public Task<ArticleDto[]?> GetArticlesOfSourceByName(string name)
    {
        throw new NotImplementedException();
    }

    public Task<SourceDto?> GetSourceById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<SourceDto[]?> GetSourceByName(string name)
    {
        throw new NotImplementedException();
    }
}
