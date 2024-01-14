using MediatR;

namespace ArticleAggregator.Data.CQS.Articles.Queries;

public class GetAUnratedArticlesQuery : IRequest<Guid[]>
{
    public int MaxTake { get; set; }

    public GetAUnratedArticlesQuery(int maxTake = 25)
    {
        MaxTake = maxTake;
    }
}
