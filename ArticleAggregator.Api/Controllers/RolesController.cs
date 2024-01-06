using ArticleAggregator.Core;
using ArticleAggregator.Mapping;
using ArticleAggregator.Models;
using ArticleAggregator.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArticleAggregator.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RolesController : ControllerBase
{
    private readonly IRoleService _roleService;
    private readonly RoleMapper _roleMapper;

    public RolesController(IRoleService roleService,
        RoleMapper roleMapper)
    {
        _roleService = roleService;
        _roleMapper = roleMapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllRoles()
    {
        var roles = await _roleService.GetAllRoles();
        return Ok(roles);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRoleById(Guid id)
    {
        var role = await _roleService.GetRoleById(id);
        return Ok(role);
    }

    //[HttpGet("{name}")]
    //public async Task<IActionResult> GetRoleByName(string name)
    //{
    //    var role = await _roleService.GetRoleByName(name);
    //    return Ok(role);
    //}

    [HttpPost]
    public async Task<IActionResult> CreateRole([FromBody] RoleModel roleModel)
    {
        var dto = _roleMapper.RoleModelToRoleDto(roleModel);
        await _roleService.CreateRole(dto);
        return Ok();
    }

    [HttpPatch]
    public async Task<IActionResult> UpdateRoleById(Guid id, string name)
    {
        await _roleService.UpdateRoleById(id, name);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRoleById(Guid id)
    {
        await _roleService.DeleteRoleById(id);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteRoleByName(string name)
    {
        await _roleService.DeleteRoleByName(name);
        return Ok();
    }
}
