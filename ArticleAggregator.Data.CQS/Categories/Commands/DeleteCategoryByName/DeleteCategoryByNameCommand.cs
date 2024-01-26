using MediatR;

namespace ArticleAggregator.Data.CQS.Categories.Commands.DeleteCategoryByName;

public class DeleteCategoryByNameCommand : IRequest
{
    public string Name { get; set; }
}
