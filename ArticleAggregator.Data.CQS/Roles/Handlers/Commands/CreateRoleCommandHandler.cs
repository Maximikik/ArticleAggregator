using ArticleAggregator.Data.CQS.Roles.Commands;
using ArticleAggregator.Data.CustomExceptions;
using ArticleAggregator.Mapping;
using MediatR;

namespace ArticleAggregator.Data.CQS.Roles.Handlers.Commands;

public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand>
{
    private readonly ArticlesAggregatorDbContext _dbContext;
    private readonly RoleMapper _mapper;

    public CreateRoleCommandHandler(ArticlesAggregatorDbContext dbContext,
        RoleMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        _ = request.RoleDto ?? throw new NotFoundException("Role");

        var role = _mapper.RoleDtoToRole(request.RoleDto);

        await _dbContext.Roles.AddAsync(role, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
