using ArticleAggregator.Core;
using MediatR;

namespace ArticleAggregator.Data.CQS.Commands;

public class CreateArticleCommand : IRequest
{
    public ArticleDto ArticleDto { get; set; } = null!;
}
