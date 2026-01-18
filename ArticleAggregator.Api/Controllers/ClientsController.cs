using ArticleAggregator.Core.Dto;
using ArticleAggregator.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArticleAggregator.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientsController(IClientService _clientService, ITokenService _tokenService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _clientService.GetAllClients());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetClientById(Guid id)
    {
        return Ok(await _clientService.GetClientById(id));
    }

    [HttpGet("{roleName}")]
    public async Task<IActionResult> GetClientsByRole(string roleName)
    {
        return Ok(await _clientService.GetClientsByRole(roleName));
    }

    [HttpPost]
    public async Task<IActionResult> CreateClient(ClientDto request)
    {
        await _clientService.RegisterUser(request);

        var client = await _clientService.GetClientByLogin(request.Email);

        return Created($"clients/{client!.Id}", null);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        await _clientService.DeleteClient(id);

        return Ok();
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateUser()
    {
        return Ok();
    }
}
