using ArticleAggregator.Core.Dto;
using MediatR;

namespace ArticleAggregator.Data.CQS.Categories.Commands.CreateCategory;

public class CreateCategoryCommand : IRequest
{
    public CategoryDto CategoryDto { get; set; } = null!;
}
