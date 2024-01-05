using ArticleAggregator.Core;
using ArticleAggregator.Services.Interfaces;

namespace ArticleAggregator.Services;

public class RoleService : IRoleService
{
    public Task<Guid?> CreateRole(RoleDto roleDto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteRoleById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task DeleteRoleByName(string name)
    {
        throw new NotImplementedException();
    }

    public Task<RoleDto[]?> GetAllRoles()
    {
        throw new NotImplementedException();
    }

    public Task<RoleDto?> GetRoleById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<RoleDto?> GetRoleByName(string name)
    {
        throw new NotImplementedException();
    }

    public Task<Guid?> UpdateRoleById(Guid id)
    {
        throw new NotImplementedException();
    }
}
