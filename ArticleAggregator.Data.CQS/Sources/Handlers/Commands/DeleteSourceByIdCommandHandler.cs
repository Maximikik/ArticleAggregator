using ArticleAggregator.Data.CQS.Sources.Commands;
using ArticleAggregator.Mapping;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArticleAggregator.Data.CQS.Sources.Handlers.Commands;

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
            ?? throw new Exception();

        _dbContext.Sources.Remove(sourceToDelete);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
