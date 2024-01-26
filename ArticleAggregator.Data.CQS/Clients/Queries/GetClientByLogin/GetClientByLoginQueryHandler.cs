using ArticleAggregator.Data.CustomExceptions;
using ArticleAggregator.Data.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArticleAggregator.Data.CQS.Clients.Queries.GetClientByLogin;

public class GetClientByLoginQueryHandler : IRequestHandler<GetClientByLoginQuery, Client>
{
    private readonly ArticlesAggregatorDbContext _dbContext;

    public GetClientByLoginQueryHandler(ArticlesAggregatorDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Client> Handle(GetClientByLoginQuery request,
        CancellationToken cancellationToken)
    {
        var client = await _dbContext.Clients
            .FirstOrDefaultAsync(client => client.Login.Equals(request.Login),
                cancellationToken: cancellationToken)
            ?? throw new NotFoundException("Client", request.Login);

        return client;
    }
}
