using ArticleAggregator.Data.Entities;
using MediatR;

namespace ArticleAggregator.Data.CQS.Articles.Queries.GetArticleByName;

public class GetArticleByTitleQuery : IRequest<Article>
{
    public string ArticleTitle { get; set; } = null!;
}
