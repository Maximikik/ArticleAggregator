using ArticleAggregator.Data.Entities;
using MediatR;

namespace ArticleAggregator.Data.CQS.Categories.Queries;

public class GetCategoryByIdQuery : IRequest<Category>
{
    public Guid Id { get; set; }
}
