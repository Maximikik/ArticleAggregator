using ArticleAggregator.Core.Dto;

namespace ArticleAggregator.Services.Interfaces;

public interface IRoleService
{
    public Task<RoleDto[]?> GetAllRoles();
    public Task<RoleDto?> GetRoleById(Guid id);
    public Task<RoleDto?> GetRoleByName(string name);
    public Task CreateRole(RoleDto roleDto);
    public Task UpdateRoleById(Guid id, string name);
    public Task DeleteRoleById(Guid id);
    public Task DeleteRoleByName(string name);
}
