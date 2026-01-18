using ArticleAggregator.Core.Models;
using MediatR;

namespace ArticleAggregator.Data.CQS.Articles.Queries.GetArticleById;

public class GetArticleByIdQuery : IRequest<ArticleModel>
{
    public Guid Id { get; set; }
}
