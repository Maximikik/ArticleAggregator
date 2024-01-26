using ArticleAggregator.Data.Entities;
using MediatR;

namespace ArticleAggregator.Data.CQS.Sources.Queries.GetArticlesOfSourceById;

public class GetArticlesOfSourceByIdQuery : IRequest<List<Article>>
{
    public Guid Id { get; set; }
}
