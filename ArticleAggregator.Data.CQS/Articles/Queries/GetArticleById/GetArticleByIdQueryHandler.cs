using ArticleAggregator.Core.Models;
using ArticleAggregator.Data.CustomExceptions;
using ArticleAggregator.Data.Entities;
using ArticleAggregator.Mapping;
using ArticleAggregator_Repositories;
using MediatR;

namespace ArticleAggregator.Data.CQS.Articles.Queries.GetArticleById;

public class GetArticleByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetArticleByIdQuery, ArticleModel>
{
    public async Task<ArticleModel> Handle(GetArticleByIdQuery request, CancellationToken cancellationToken)
    {
        var article = await unitOfWork.ArticleRepository
            .GetById(request.Id)
            ?? throw new NotFoundException("Article", request.Id);

        return mapper.Map<Article, ArticleModel>(article);
    }
}