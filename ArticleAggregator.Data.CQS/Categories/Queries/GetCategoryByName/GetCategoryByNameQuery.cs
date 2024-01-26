using ArticleAggregator.Data.Entities;
using MediatR;

namespace ArticleAggregator.Data.CQS.Categories.Queries.GetCategoryByName;

public class GetCategoryByNameQuery : IRequest<Category>
{
    public string Name { get; set; } = null!;
}
