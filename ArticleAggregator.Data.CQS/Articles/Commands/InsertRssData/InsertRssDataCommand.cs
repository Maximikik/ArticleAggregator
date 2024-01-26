using ArticleAggregator.Core.Dto;
using MediatR;

namespace ArticleAggregator.Data.CQS.Articles.Commands.InsertRssData;

public class InsertRssDataCommand : IRequest
{
    public ArticleDto[] Articles { get; set; } = null!;
}
