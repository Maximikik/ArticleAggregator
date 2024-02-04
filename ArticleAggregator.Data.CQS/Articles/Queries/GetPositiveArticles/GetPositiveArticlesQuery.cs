using ArticleAggregator.Data.Entities;
using MediatR;

namespace ArticleAggregator.Data.CQS.Articles.Queries.GetPositive;

public class GetPositiveArticlesQuery : IRequest<List<Article>>
{
    public int rateGreaterThan { get; set; } = 5;
}
