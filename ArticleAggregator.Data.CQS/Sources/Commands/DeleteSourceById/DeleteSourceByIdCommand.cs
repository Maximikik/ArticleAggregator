using MediatR;

namespace ArticleAggregator.Data.CQS.Sources.Commands.DeleteSourceById;

public class DeleteSourceByIdCommand : IRequest
{
    public Guid Id { get; set; }
}
