using ArticleAggregator.Data.Entities;
using MediatR;

namespace ArticleAggregator.Data.CQS.Articles.Queries;

public class GetArticleByIdQuery : IRequest<Article>
{
    public Guid Id { get; set; }
}
