using MediatR;

namespace ArticleAggregator.Data.CQS.Articles.Commands.UpdateArticleText;

public class UpdateArticleTextCommand : IRequest
{
    public Dictionary<Guid, string> ArticlesData { get; set; } = null!;
}
