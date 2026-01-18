using ArticleAggregator.Core.Models;
using ArticleAggregator.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArticleAggregator.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly IClientService _clientService;
    private readonly ITokenService _tokenService;


    public AuthenticationController(IClientService clientService, ITokenService tokenService)
    {
        _clientService = clientService;
        _tokenService = tokenService;
    }

    [HttpPost]
    public async Task<IActionResult> GenerateToken(LoginModel request)
    {
        var isClientCorrect = await _clientService.IsPasswordCorrect(request.Email, request.Password);
        if (isClientCorrect)
        {
            var clientDto = await _clientService.GetClientByLogin(request.Email);
            var jwtToken = await _tokenService.GenerateJwtToken(clientDto);
            var refreshToken = await _tokenService.AddRefreshToken(clientDto.Email,
                HttpContext.Connection.RemoteIpAddress!.MapToIPv4().ToString());
            return Ok(new TokenResponseModel { AccessToken = jwtToken, RefreshToken = refreshToken });
        }

        return Unauthorized();
    }

    [HttpPost]
    [Route("Refresh")]
    public async Task<IActionResult> GenerateToken(RefreshTokenModel request)
    {
        //can be refactored
        var isRefreshTokenValid = await _tokenService.CheckRefreshToken(request.RefreshToken);
        if (isRefreshTokenValid)
        {
            var clientDto = await _clientService.GetClientByRefreshToken(request.RefreshToken);
            var jwtToken = await _tokenService.GenerateJwtToken(clientDto);
            var refreshToken = await _tokenService.AddRefreshToken(clientDto.Email,
                HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString());
            await _tokenService.RemoveRefreshToken(request.RefreshToken);
            return Ok(new TokenResponseModel { AccessToken = jwtToken, RefreshToken = refreshToken });
        }

        return Unauthorized();
    }

    //[HttpDelete]
    //[Route("Revoke")]
    //public async Task<IActionResult> RevokeToken(RefreshTokenModel request)
    //{
    //    //todo check if exists to return correct status code
    //    //todo check that RT for same user as from request
    //    await _tokenService.RemoveRefreshToken(request.RefreshToken);
    //    return Ok();
    //}
}
