using ArticleAggregator.Core.Dto;
using ArticleAggregator.Data.CQS.Categories.Commands;
using ArticleAggregator.Data.CQS.Categories.Queries;
using ArticleAggregator.Mapping;
using ArticleAggregator.Services.Interfaces;
using ArticleAggregator_Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace ArticleAggregator.Services;

public class CategoryService : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly CategoryMapper _categoryMapper;
    private readonly IMediator _mediator;
    private readonly IConfiguration _configuration;
    public CategoryService(IUnitOfWork unitOfWork,
      CategoryMapper categoryMapper, IMediator mediator, IConfiguration configuration)
    {
        _unitOfWork = unitOfWork;
        _categoryMapper = categoryMapper;
        _mediator = mediator;
        _configuration = configuration;
    }

    public async Task CreateCategory(CategoryDto dto)
    {
        var command = new CreateCategoryCommand() { CategoryDto = dto };
        await _mediator.Send(command);
    }

    public async Task DeleteCategoryById(Guid id)
    {
        var command = new DeleteCategoryByIdCommand() { Id = id };
        await _mediator.Send(command);
    }

    public async Task DeleteCategoryByName(string name)
    {
        var command = new DeleteCategoryByNameCommand() { Name = name };
        await _mediator.Send(command);
    }

    public async Task<CategoryDto[]?> GetAllCategories()
    {
        var categories = await _mediator.Send(new GetAllCategoriesQuery());

        var categoriesDto = new CategoryDto[categories.Count()];

        categories.ForEach(category =>
        {
            categoriesDto[categories.IndexOf(category)] = _categoryMapper.CategoryToCategoryDto(category);
        });

        return categoriesDto;
    }

    public async Task<CategoryDto?> GetCategoryById(Guid id)
    {
        var command = new GetCategoryByIdQuery() { Id = id };
        var category = await _mediator.Send(command);

        var categoryDto = _categoryMapper.CategoryToCategoryDto(category);

        return categoryDto;
    }

    public async Task<CategoryDto?> GetCategoryByName(string name)
    {
        var command = new GetCategoryByNameQuery() { Name = name };
        var category = await _mediator.Send(command);

        var categoryDto = _categoryMapper.CategoryToCategoryDto(category);

        return categoryDto;
    }
}
