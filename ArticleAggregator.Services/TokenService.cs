using ArticleAggregator.Core.Dto;
using ArticleAggregator.Data.CQS.Clients.Queries;
using ArticleAggregator.Data.CQS.Roles.Queries;
using ArticleAggregator.Data.CQS.Tokens.Commands;
using ArticleAggregator.Services.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ArticleAggregator.Services;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;
    private readonly IMediator _mediator;

    public TokenService(IConfiguration configuration, IMediator mediator)
    {
        _configuration = configuration;
        _mediator = mediator;
    }

    public async Task<Guid> AddRefreshToken(string login, string ipAddress)
    {
        var client = await _mediator.Send(new GetClientByLoginQuery() { Login = login });
        //todo change to be more correct from CQRS point of view
        var refreshToken = await _mediator.Send(new AddRefreshTokenCommand() { ClientId = client.Id, Ip = ipAddress });
        return refreshToken;
    }

    public async Task<bool> CheckRefreshToken(Guid requestRefreshToken)
    {
        var rt = await _mediator.Send(new GetRefreshTokenQuery { Id = requestRefreshToken });
        if (rt != null && rt.ExpiringAt.ToUniversalTime() < DateTime.UtcNow)
        {
            return true;
        }

        return false;
    }

    public async Task<string> GenerateJwtToken(ClientDto clientDto)
    {
        _ = int.TryParse(_configuration["Jwt:Lifetime"], out var lifetime);
        var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]!);
        var issuer = _configuration["Jwt:Issuer"];
        var audience = _configuration["Jwt:Audience"];

        var clientRole = await _mediator.Send(new GetRoleByIdQuery { Id = clientDto.RoleId });

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, clientDto.Login),
                new Claim(ClaimTypes.Role, clientRole.Name),
                new Claim("Audience",audience!),
                new Claim("Issuer",issuer!)
            }),
            Expires = DateTime.UtcNow.AddMinutes(lifetime),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }

    public async Task RemoveRefreshToken(Guid requestRefreshToken)
    {
        await _mediator.Send(new DeleteRefreshTokenCommand()
        {
            Id = requestRefreshToken
        });
    }
}
