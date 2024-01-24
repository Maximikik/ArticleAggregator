using ArticleAggregator.Core.Dto;
using MediatR;

namespace ArticleAggregator.Data.CQS.Articles.Commands;

public class InsertRssDataCommand : IRequest
{
    public ArticleDto[] Articles { get; set; } = null!;
}
