using ArticleAggregator.Data.Entities;
using MediatR;

namespace ArticleAggregator.Data.CQS.Categories.Queries;

public class GetCategoryByNameCommand : IRequest<Category>
{
    public string Name { get; set; } = null!;
}
