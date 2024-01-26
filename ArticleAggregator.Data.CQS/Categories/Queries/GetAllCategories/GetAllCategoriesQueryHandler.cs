using ArticleAggregator.Data.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArticleAggregator.Data.CQS.Categories.Queries.GetAllCategories;

public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, List<Category>>
{
    private readonly ArticlesAggregatorDbContext _dbContext;

    public GetAllCategoriesQueryHandler(ArticlesAggregatorDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Category>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        return await _dbContext.Categories.ToListAsync(cancellationToken);
    }
}
