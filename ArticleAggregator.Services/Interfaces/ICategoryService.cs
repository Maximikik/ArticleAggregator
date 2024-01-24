using ArticleAggregator.Core.Dto;

namespace ArticleAggregator.Services.Interfaces;

public interface ICategoryService
{
    public Task<CategoryDto[]?> GetAllCategories();
    public Task<CategoryDto?> GetCategoryById(Guid id);
    public Task<CategoryDto?> GetCategoryByName(string name);
    public Task DeleteCategoryById(Guid id);
    public Task DeleteCategoryByName(string name);

    public Task CreateCategory(CategoryDto dto);
}
