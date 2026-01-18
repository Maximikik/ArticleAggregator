using ArticleAggregator.Core.Dto;
using ArticleAggregator.Data.CQS.Categories.Commands.CreateCategory;
using ArticleAggregator.Data.CQS.Categories.Commands.DeleteCategoryById;
using ArticleAggregator.Data.CQS.Categories.Commands.DeleteCategoryByName;
using ArticleAggregator.Data.CQS.Categories.Queries.GetAllCategories;
using ArticleAggregator.Data.CQS.Categories.Queries.GetCategoryById;
using ArticleAggregator.Data.CQS.Categories.Queries.GetCategoryByName;
using ArticleAggregator.Data.Entities;
using ArticleAggregator.Mapping;
using ArticleAggregator.Services.Interfaces;
using ArticleAggregator_Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace ArticleAggregator.Services.Services;

public class CategoryService(IUnitOfWork _unitOfWork, IMapper mapper, IMediator _mediator, IConfiguration _configuration) : ICategoryService
{
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
            categoriesDto[categories.IndexOf(category)] = mapper.Map<Category, CategoryDto>(category);
        });

        return categoriesDto;
    }

    public async Task<CategoryDto?> GetCategoryById(Guid id)
    {
        var command = new GetCategoryByIdQuery() { Id = id };
        var category = await _mediator.Send(command);

        var categoryDto = mapper.Map<Category, CategoryDto>(category);

        return categoryDto;
    }

    public async Task<CategoryDto?> GetCategoryByName(string name)
    {
        var command = new GetCategoryByNameQuery() { Name = name };
        var category = await _mediator.Send(command);

        var categoryDto = mapper.Map<Category, CategoryDto>(category);

        return categoryDto;
    }
}
