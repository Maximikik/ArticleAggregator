using ArticleAggregator.Data.Entities;
using MediatR;

namespace ArticleAggregator.Data.CQS.Sources.Queries;

public class GetAllSourcesQuery : IRequest<List<Source>>
{ }
