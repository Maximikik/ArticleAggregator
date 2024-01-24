using ArticleAggregator.Core.Dto;
using ArticleAggregator.Data.CQS.Roles.Commands;
using ArticleAggregator.Data.CQS.Roles.Queries;
using ArticleAggregator.Mapping;
using ArticleAggregator.Services.Interfaces;
using ArticleAggregator_Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace ArticleAggregator.Services;

public class RoleService : IRoleService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly RoleMapper _roleMapper;
    private readonly IMediator _mediator;
    private readonly IConfiguration _configuration;
    public RoleService(IUnitOfWork unitOfWork,
      RoleMapper roleMapper, IMediator mediator, IConfiguration configuration)
    {
        _unitOfWork = unitOfWork;
        _roleMapper = roleMapper;
        _mediator = mediator;
        _configuration = configuration;
    }

    public async Task CreateRole(RoleDto roleDto)
    {
        var command = new CreateRoleCommand() { RoleDto = roleDto };

        await _mediator.Send(command);
    }

    public async Task DeleteRoleById(Guid id)
    {
        var command = new DeleteRoleByIdCommand() { Id = id };

        await _mediator.Send(command);
    }

    public async Task DeleteRoleByName(string name)
    {
        var command = new DeleteRoleByNameCommand() { Name = name };

        await _mediator.Send(command);
    }

    public async Task<RoleDto[]?> GetAllRoles()
    {
        var roles = await _mediator.Send(new GetAllRolesQuery());

        var rolesDto = new RoleDto[roles.Count()];

        roles.ForEach(role =>
        {
            rolesDto[roles.IndexOf(role)] = _roleMapper.RoleToRoleDto(role);
        });

        return rolesDto;
    }

    public async Task<RoleDto?> GetRoleById(Guid id)
    {
        var command = new GetRoleByIdQuery() { Id = id };

        var role = await _mediator.Send(command);
        var roleDto = _roleMapper.RoleToRoleDto(role);

        return roleDto;
    }

    public async Task<RoleDto?> GetRoleByName(string name)
    {
        var command = new GetRoleByNameQuery() { Name = name };

        var role = await _mediator.Send(command);
        var roleDto = _roleMapper.RoleToRoleDto(role);

        return roleDto;
    }

    public async Task UpdateRoleById(Guid id, string name)
    {
        var command = new UpdateRoleByIdCommand
        {
            Id = id,
            Name = name
        };

        await _mediator.Send(command);
    }
}
