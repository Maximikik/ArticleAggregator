using MediatR;

namespace ArticleAggregator.Data.CQS.Categories.Commands;

public class DeleteCategoryByIdCommand : IRequest
{
    public Guid Id { get; set; }
}
