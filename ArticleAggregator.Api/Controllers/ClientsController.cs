using ArticleAggregator.Core.Dto;
using ArticleAggregator.Mapping;
using ArticleAggregator.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArticleAggregator.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientsController : ControllerBase
{
    private readonly IClientService _clientService;
    private readonly ClientMapper _clientMapper;
    private readonly ITokenService _tokenService;

    public ClientsController(IClientService clientService,
        ClientMapper clientMapper, ITokenService tokenService)
    {
        _clientService = clientService;
        _clientMapper = clientMapper;
        _tokenService = tokenService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var clientsDto = await _clientService.GetAllClients();

        var clients = clientsDto!.Select(dto => _clientMapper.ClientDtoToClient(dto));

        return Ok(clients);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetClientById(Guid id)
    {
        var clientDto = await _clientService.GetClientById(id);

        var client = _clientMapper.ClientDtoToClient(clientDto!);

        return Ok(client);
    }

    [HttpGet("{roleName}")]
    public async Task<IActionResult> GetClientsByRole(string roleName)
    {
        var clientsDto = await _clientService.GetClientsByRole(roleName);

        var clients =  clientsDto!.Select(dto => _clientMapper.ClientDtoToClient(dto));

        return Ok(clients);
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
