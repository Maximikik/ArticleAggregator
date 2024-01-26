using MediatR;

namespace ArticleAggregator.Data.CQS.Articles.Commands.SetArticleRate;

public class SetArticleRateCommand : IRequest
{
    public Guid Id { get; set; }
    public int Rate { get; set; }
}
