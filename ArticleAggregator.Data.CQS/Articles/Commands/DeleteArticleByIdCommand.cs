using MediatR;

namespace ArticleAggregator.Data.CQS.Articles.Commands;

public class DeleteArticleByIdCommand : IRequest<Guid>
{
    public Guid ArticleId { get; set; }
}
