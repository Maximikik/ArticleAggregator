using ArticleAggregator.Data.CustomExceptions;
using ArticleAggregator.Data.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArticleAggregator.Data.CQS.Categories.Queries.GetCategoryByName;

public class GetCategoryByNameQueryHandler : IRequestHandler<GetCategoryByNameQuery, Category>
{
    private readonly ArticlesAggregatorDbContext _dbContext;

    public GetCategoryByNameQueryHandler(ArticlesAggregatorDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Category> Handle(GetCategoryByNameQuery request, CancellationToken cancellationToken)
    {
        var category = await _dbContext.Categories.FirstOrDefaultAsync(
            category => category.Name.Equals(request.Name), cancellationToken)
            ?? throw new NotFoundException("Category", request.Name);

        return category;
    }
}