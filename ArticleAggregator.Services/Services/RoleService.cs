using ArticleAggregator.Core.Dto;
using ArticleAggregator.Data.CQS.Roles.Commands.CreateRole;
using ArticleAggregator.Data.CQS.Roles.Commands.DeleteRoleById;
using ArticleAggregator.Data.CQS.Roles.Commands.DeleteRoleByName;
using ArticleAggregator.Data.CQS.Roles.Commands.UpdateRoleById;
using ArticleAggregator.Data.CQS.Roles.Queries.GetAllRoles;
using ArticleAggregator.Data.CQS.Roles.Queries.GetRoleById;
using ArticleAggregator.Data.CQS.Roles.Queries.GetRoleByName;
using ArticleAggregator.Data.Entities;
using ArticleAggregator.Mapping;
using ArticleAggregator.Services.Interfaces;
using ArticleAggregator_Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace ArticleAggregator.Services.Services;

public class RoleService(
    IUnitOfWork _unitOfWork,
    IMapper mapper,
    IMediator _mediator,
    IConfiguration _configuration
    ) : IRoleService
{
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
            rolesDto[roles.IndexOf(role)] = mapper.Map<Role, RoleDto>(role);
        });

        return rolesDto;
    }

    public async Task<RoleDto?> GetRoleById(Guid id)
    {
        var command = new GetRoleByIdQuery() { Id = id };

        var role = await _mediator.Send(command);
        var roleDto = mapper.Map<Role, RoleDto>(role);

        return roleDto;
    }

    public async Task<RoleDto?> GetRoleByName(string name)
    {
        var command = new GetRoleByNameQuery() { Name = name };

        var role = await _mediator.Send(command);
        var roleDto = mapper.Map<Role, RoleDto>(role);

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
