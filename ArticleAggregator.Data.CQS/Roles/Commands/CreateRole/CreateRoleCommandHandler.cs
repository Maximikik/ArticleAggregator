using ArticleAggregator.Core.Dto;
using ArticleAggregator.Data.CustomExceptions;
using ArticleAggregator.Data.Entities;
using ArticleAggregator.Mapping;
using MediatR;

namespace ArticleAggregator.Data.CQS.Roles.Commands.CreateRole;

public class CreateRoleCommandHandler(ArticlesAggregatorDbContext _dbContext, IMapper mapper) : IRequestHandler<CreateRoleCommand>
{
    public async Task Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        _ = request.RoleDto ?? throw new NotFoundException("Role");

        var role = mapper.Map<RoleDto, Role>(request.RoleDto);

        await _dbContext.Roles.AddAsync(role, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
