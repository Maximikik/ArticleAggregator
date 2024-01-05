using ArticleAggregator.Core;
using MediatR;

namespace ArticleAggregator.Data.CQS.Categories.Commands;

public class CreateCategoryCommand : IRequest
{
    public CategoryDto CategoryDto { get; set; } = null!;
}
