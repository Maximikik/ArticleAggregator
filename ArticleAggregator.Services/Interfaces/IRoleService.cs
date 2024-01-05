using ArticleAggregator.Core;

namespace ArticleAggregator.Services.Interfaces;

public interface IRoleService
{
    public Task<RoleDto[]?> GetAllRoles();
    public Task<RoleDto?> GetRoleById(Guid id);
    public Task<RoleDto?> GetRoleByName(string name);
    public Task<Guid?> CreateRole(RoleDto roleDto);
    public Task<Guid?> UpdateRoleById(Guid id);
    public Task DeleteRoleById(Guid id);
    public Task DeleteRoleByName(string name);
}
