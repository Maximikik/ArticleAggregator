using ArticleAggregator.Data.CustomExceptions;
using ArticleAggregator.Mapping;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArticleAggregator.Data.CQS.Categories.Commands.DeleteCategoryByName;

public class DeleteCategoryByNameCommandHandler(ArticlesAggregatorDbContext _dbContext, IMapper _mapper) : IRequestHandler<DeleteCategoryByNameCommand>
{
    public async Task Handle(DeleteCategoryByNameCommand request, CancellationToken cancellationToken)
    {
        var categoryToDelete = await _dbContext.Categories.FirstOrDefaultAsync(
            category => category.Name.Equals(request.Name), cancellationToken)
            ?? throw new NotFoundException("Category", request.Name);

        _dbContext.Categories.Remove(categoryToDelete);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}