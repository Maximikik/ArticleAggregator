using ArticleAggregator.Data.CustomExceptions;
using ArticleAggregator.Mapping;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArticleAggregator.Data.CQS.Categories.Commands.DeleteCategoryById;

public class DeleteCategoryByIdCommandHandler : IRequestHandler<DeleteCategoryByIdCommand>
{
    private readonly ArticlesAggregatorDbContext _dbContext;
    private readonly CategoryMapper _mapper;

    public DeleteCategoryByIdCommandHandler(ArticlesAggregatorDbContext dbContext,
        CategoryMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task Handle(DeleteCategoryByIdCommand request, CancellationToken cancellationToken)
    {
        var categoryToDelete = await _dbContext.Categories.FirstOrDefaultAsync(
            category => category.Id.Equals(request.Id), cancellationToken)
            ?? throw new NotFoundException("Category", request.Id);

        _dbContext.Categories.Remove(categoryToDelete);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
