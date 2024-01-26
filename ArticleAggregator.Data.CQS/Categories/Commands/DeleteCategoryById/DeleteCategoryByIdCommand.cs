using MediatR;

namespace ArticleAggregator.Data.CQS.Categories.Commands.DeleteCategoryById;

public class DeleteCategoryByIdCommand : IRequest
{
    public Guid Id { get; set; }
}
