using MediatR;

namespace ArticleAggregator.Data.CQS.Commands;

public class UpdateArticleTextCommand : IRequest
{
    public Dictionary<Guid, string> ArticlesData { get; set; } = null!;
}
