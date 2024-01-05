using ArticleAggregator.Data.Entities;
using MediatR;

namespace ArticleAggregator.Data.CQS.Sources.Queries;

public class GetArticlesOfSourceByIdQuery : IRequest<List<Article>>
{
    public Guid Id { get; set; }
}
