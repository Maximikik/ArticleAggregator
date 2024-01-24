using ArticleAggregator.Data.CQS.Clients.Queries;
using ArticleAggregator.Data.CustomExceptions;
using ArticleAggregator.Data.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArticleAggregator.Data.CQS.Clients.Handlers.Queries;

public class GetClientByIdQueryHandler : IRequestHandler<GetClientByIdQuery, Client>
{
    private readonly ArticlesAggregatorDbContext _dbContext;

    public GetClientByIdQueryHandler(ArticlesAggregatorDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Client> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
    {
        var client = await _dbContext.Clients.FirstOrDefaultAsync(client => client.Id.Equals(request.Id), cancellationToken)
            ?? throw new NotFoundException("Client", request.Id);

        return client;
    }
}
