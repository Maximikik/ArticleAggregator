using ArticleAggregator.Core.Models;
using ArticleAggregator.Data.CQS.Articles.Queries.GetPositive;
using ArticleAggregator.Data.CustomExceptions;
using ArticleAggregator.Data.Entities;
using ArticleAggregator.Mapping;
using ArticleAggregator_Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArticleAggregator.Data.CQS.Articles.Queries.GetPositiveArticles;

public class GetPositiveArticlesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetPositiveArticlesQuery, List<ArticleModel>>
{
    public async Task<List<ArticleModel>> Handle(GetPositiveArticlesQuery request, CancellationToken cancellationToken)
    {
        var articles = await unitOfWork.ArticleRepository.FindBy(article => article.Rating >= request.rateGreaterThan).ToListAsync()
            ?? throw new NotFoundException("Article");

        return articles.Select(mapper.Map<Article, ArticleModel>).ToList();
    }
}
