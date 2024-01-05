using ArticleAggregator.Core;
using ArticleAggregator.Data.Entities;
using ArticleAggregator.Models;
using Riok.Mapperly.Abstractions;

namespace ArticleAggregator.Mapping;

[Mapper]
public partial class RoleMapper
{
    public partial RoleDto RoleToRoleDto(Role role);
    public partial Role RoleDtoToRole(RoleDto roleDto);
    public partial RoleModel RoleDtoToRoleModel(RoleDto roleDto);
    public partial RoleDto RoleModelToRoleDto(RoleModel roleModel);
}
