using MediatR;

namespace ArticleAggregator.Data.CQS.Articles.Queries;

public class GetArticleTextQuery : IRequest<string>
{
    public Guid Id { get; set; }
}
