using ArticleAggregator.Data.Entities;
using MediatR;

namespace ArticleAggregator.Data.CQS.Queries;

public class GetArticleByIdQuery : IRequest<Article>
{
    public Guid Id { get; set; }
}
