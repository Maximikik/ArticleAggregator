using ArticleAggregator.Data.CustomExceptions;
using ArticleAggregator.Data.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArticleAggregator.Data.CQS.Clients.Queries.GetClientByRole;

public class GetClientsByRoleQueryHandler : IRequestHandler<GetClientsByRoleQuery, List<Client>>
{
    private readonly ArticlesAggregatorDbContext _dbContext;

    public GetClientsByRoleQueryHandler(ArticlesAggregatorDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Client>> Handle(GetClientsByRoleQuery request, CancellationToken cancellationToken)
    {
        //var role = await _dbContext.Roles.FirstOrDefaultAsync(name => name.Equals(request.roleName), cancellationToken)
        //    ?? throw new NotFoundException("Role", request.roleName);

        var clients = await _dbContext.Clients.Where(client => client.Role.Name.Equals(request.roleName)).ToListAsync()
            ?? throw new NotFoundException("Role", request.roleName);

        return clients;
    }
}
