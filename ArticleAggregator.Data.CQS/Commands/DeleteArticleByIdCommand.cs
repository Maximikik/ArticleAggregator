using MediatR;

namespace ArticleAggregator.Data.CQS.Commands;

public class DeleteArticleByIdCommand : IRequest<Guid>
{
    public Guid ArticleId { get; set; }
}
