using ArticleAggregator.Core;
using MediatR;

namespace ArticleAggregator.Data.CQS.Commands;

public class InsertRssDataCommand : IRequest
{
    public ArticleDto[] Articles { get; set; } = null!;
}
