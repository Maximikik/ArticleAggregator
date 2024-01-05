using MediatR;

namespace ArticleAggregator.Data.CQS.Articles.Commands;

public class CreateArticleWithSourceCommand : IRequest
{
    public string Title { get; set; } = null!;
    public double Rating { get; set; }
    public Guid ArticleSourceId { get; set; }
}
