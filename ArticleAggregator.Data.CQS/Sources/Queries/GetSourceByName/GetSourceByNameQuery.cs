using ArticleAggregator.Data.Entities;
using MediatR;

namespace ArticleAggregator.Data.CQS.Sources.Queries.GetSourceByName;

public class GetSourceByNameQuery : IRequest<Source>
{
    public string Name { get; set; } = null!;
}
