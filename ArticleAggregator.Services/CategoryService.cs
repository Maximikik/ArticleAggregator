using ArticleAggregator.Core;
using ArticleAggregator.Data.CQS.Articles.Commands;
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

    public async Task<Guid> CreateCategory(CategoryDto dto)
    {
        var command = new CreateCategoryCommand() { CategoryDto = dto };
        var id = command.CategoryDto.Id;
        await _mediator.Send(command);
        return id;
    }

    public Task DeleteCategoryById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task DeleteCategoryByName(string name)
    {
        throw new NotImplementedException();
    }

    public Task<CategoryDto?> GetCategoryById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<CategoryDto[]?> GetCategoryByName(string name)
    {
        throw new NotImplementedException();
    }
}
