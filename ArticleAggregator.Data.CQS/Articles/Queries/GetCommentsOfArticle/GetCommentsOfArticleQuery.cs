using ArticleAggregator.Data.Entities;
using MediatR;

namespace ArticleAggregator.Data.CQS.Articles.Queries.GetCommentsOfArticle;

public class GetCommentsOfArticleQuery: IRequest<List<Comment>>
{
    public Guid Id { get; set; }
}
