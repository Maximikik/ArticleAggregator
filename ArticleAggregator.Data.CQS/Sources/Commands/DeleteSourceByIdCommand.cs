using MediatR;

namespace ArticleAggregator.Data.CQS.Sources.Commands;

public class DeleteSourceByIdCommand : IRequest
{
    public Guid Id { get; set; }
}
