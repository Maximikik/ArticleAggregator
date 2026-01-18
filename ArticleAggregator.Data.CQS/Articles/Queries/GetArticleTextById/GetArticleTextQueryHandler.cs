using ArticleAggregator.Data.CustomExceptions;
using ArticleAggregator_Repositories;
using MediatR;

namespace ArticleAggregator.Data.CQS.Articles.Queries.GetArticleTextById;

public class GetArticleTextQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetArticleTextQuery, string>
{
    public async Task<string> Handle(GetArticleTextQuery request,
        CancellationToken cancellationToken)
    {
        var article = await unitOfWork.ArticleRepository
            .GetByIdAsNoTracking(request.Id)
            ?? throw new NotFoundException("Article", request.Id);

        return article.Title;
    }
}