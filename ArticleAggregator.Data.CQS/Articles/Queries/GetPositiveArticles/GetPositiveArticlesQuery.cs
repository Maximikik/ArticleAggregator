using ArticleAggregator.Core.Models;
using MediatR;

namespace ArticleAggregator.Data.CQS.Articles.Queries.GetPositive;

public class GetPositiveArticlesQuery : IRequest<List<ArticleModel>>
{
    public int rateGreaterThan { get; set; } = 5;
}
