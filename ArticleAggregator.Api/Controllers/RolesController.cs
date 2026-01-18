using ArticleAggregator.Core.Dto;
using ArticleAggregator.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArticleAggregator.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RolesController(IRoleService _roleService) : ControllerBase
{
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
    public async Task<IActionResult> CreateRole([FromBody] RoleDto request)
    {
        await _roleService.CreateRole(request);
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
