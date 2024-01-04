using MediatR;

namespace ArticleAggregator.Data.CQS.Queries;

public class GetArticleTextQuery : IRequest<string>
{
    public Guid Id { get; set; }
}
