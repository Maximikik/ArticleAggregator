using ArticleAggregator.Core;

namespace ArticleAggregator.Services.Interfaces;

public interface ICategoryService
{
    public Task<CategoryDto?> GetCategoryById(Guid id);
    public Task<CategoryDto[]?> GetCategoryByName(string name);
    public Task DeleteCategoryById(Guid id);
    public Task DeleteCategoryByName(string name);

    public Task<Guid> CreateCategory(CategoryDto dto);
}
