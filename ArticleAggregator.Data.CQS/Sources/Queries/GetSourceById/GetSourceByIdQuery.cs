using ArticleAggregator.Data.Entities;
using MediatR;

namespace ArticleAggregator.Data.CQS.Sources.Queries.GetSourceById;

public class GetSourceByIdQuery : IRequest<Source>
{
    public Guid Id { get; set; }
}
