using ArticleAggregator.Data.CQS.Categories.Commands;
using ArticleAggregator.Mapping;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArticleAggregator.Data.CQS.Categories.Handlers.Commands;

public class DeleteCategoryByNameCommandHandler : IRequestHandler<DeleteCategoryByNameCommand>
{
    private readonly ArticlesAggregatorDbContext _dbContext;
    private readonly CategoryMapper _mapper;

    public DeleteCategoryByNameCommandHandler(ArticlesAggregatorDbContext dbContext,
        CategoryMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task Handle(DeleteCategoryByNameCommand request, CancellationToken cancellationToken)
    {
        var categoryToDelete = await _dbContext.Categories.FirstOrDefaultAsync(
            category => category.Name.Equals(request.Name), cancellationToken)
            ?? throw new Exception();

        _dbContext.Categories.Remove(categoryToDelete);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}