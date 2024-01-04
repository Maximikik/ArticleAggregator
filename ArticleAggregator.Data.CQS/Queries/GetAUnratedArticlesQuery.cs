using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleAggregator.Data.CQS.Queries;

public class GetAUnratedArticlesQuery : IRequest<Guid[]>
{
    public int MaxTake { get; set; }

    public GetAUnratedArticlesQuery(int maxTake = 25)
    {
        MaxTake = maxTake;
    }
}
