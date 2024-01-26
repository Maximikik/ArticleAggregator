using ArticleAggregator.Data.Entities;
using MediatR;

namespace ArticleAggregator.Data.CQS.Articles.Queries.GetArticleById;

public class GetArticleByIdQuery : IRequest<Article>
{
    public Guid Id { get; set; }
}
