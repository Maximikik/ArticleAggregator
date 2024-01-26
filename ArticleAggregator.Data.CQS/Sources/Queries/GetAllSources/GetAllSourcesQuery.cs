using ArticleAggregator.Data.Entities;
using MediatR;

namespace ArticleAggregator.Data.CQS.Sources.Queries.GetAllSources;

public class GetAllSourcesQuery : IRequest<List<Source>>
{ }
