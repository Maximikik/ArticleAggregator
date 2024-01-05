using MediatR;

namespace ArticleAggregator.Data.CQS.Categories.Commands;

public class DeleteCategoryByNameCommand : IRequest
{
    public string Name { get; set; }
}
