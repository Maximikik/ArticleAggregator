using ArticleAggregator.Data.CustomExceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArticleAggregator.Data.CQS.Sources.Commands.DeleteSourceById;

public class DeleteSourceByIdCommandHandler : IRequestHandler<DeleteSourceByIdCommand>
{
    private readonly ArticlesAggregatorDbContext _dbContext;

    public DeleteSourceByIdCommandHandler(ArticlesAggregatorDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task Handle(DeleteSourceByIdCommand request, CancellationToken cancellationToken)
    {
        var sourceToDelete = await _dbContext.Sources.FirstOrDefaultAsync(source => source.Id.Equals(request.Id), cancellationToken)
            ?? throw new NotFoundException("Source", request.Id);

        _dbContext.Sources.Remove(sourceToDelete);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
