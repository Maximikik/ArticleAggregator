using ArticleAggregator.Core.Dto;
using MediatR;

namespace ArticleAggregator.Data.CQS.Sources.Commands;

public class CreateSourceCommand : IRequest
{
    public SourceDto SourceDto { get; set; }
}
