using ArticleAggregator.Core;
using ArticleAggregator.Mapping;
using ArticleAggregator.Models;
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

    //[HttpGet("{id}")]
    //public async Task<IActionResult> GetUserById(Guid id)
    //{
    //    var query = new GetClie
    //}

    [HttpGet]
    public async Task<IActionResult> GetUsers(/*filter*/)
    {
        return Ok(await _clientService.GetAllClients());
    }

    [HttpPost]
    public async Task<IActionResult> CreateClient(ClientDto request)
    {
        //validation

        //var clientDto = _clientMapper.RegisterModelToClientDto(request);
        await _clientService.RegisterUser(request);

        var client = await _clientService.GetClientByLogin(request.Login);

        //var token = await _tokenService.GenerateJwtToken(user);

        return Created($"users/{client.Id}", null);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser()
    {
        return Ok();
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateUser()
    {
        return Ok();
    }
}
