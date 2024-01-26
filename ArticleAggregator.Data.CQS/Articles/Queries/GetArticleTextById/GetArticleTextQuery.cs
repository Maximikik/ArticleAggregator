using MediatR;

namespace ArticleAggregator.Data.CQS.Articles.Queries.GetArticleTextById;

public class GetArticleTextQuery : IRequest<string>
{
    public Guid Id { get; set; }
}
