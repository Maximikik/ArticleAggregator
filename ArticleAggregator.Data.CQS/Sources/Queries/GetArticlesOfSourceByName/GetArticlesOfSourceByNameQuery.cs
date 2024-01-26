using ArticleAggregator.Data.Entities;
using MediatR;

namespace ArticleAggregator.Data.CQS.Sources.Queries.GetArticlesOfSourceByName;

public class GetArticlesOfSourceByNameQuery : IRequest<List<Article>>
{
    public string Name { get; set; } = null!;
}
