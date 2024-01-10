using ArticleAggregator.Core;
using ArticleAggregator.Data.CQS.Clients.Queries;
using ArticleAggregator.Data.CQS.CustomExceptions;
using ArticleAggregator.Data.Entities;
using ArticleAggregator.Mapping;
using ArticleAggregator.Services.Interfaces;
using ArticleAggregator_Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.Security.Cryptography;

namespace ArticleAggregator.Services;

public class ClientService : IClientService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IConfiguration _configuration;
    private readonly ClientMapper _clientMapper;
    private readonly IMediator _mediator;


    public ClientService(IUnitOfWork unitOfWork, IConfiguration configuration, ClientMapper clientMapper,
        IMediator mediator)
    {
        _unitOfWork = unitOfWork;
        _configuration = configuration;
        _clientMapper = clientMapper;
        _mediator = mediator;
    }

    public async Task<ClaimsIdentity> Authenticate(string userName)
    {
        var client = await _unitOfWork.ClientRepository
            .FindBy(login => login.Login.Equals(userName))
            .FirstOrDefaultAsync()
            ?? throw new NotFoundException("Client", userName);

        var roleName = (await _unitOfWork.RoleRepository.GetByIdAsNoTracking(client.RoleId))?.Name;

        var claims = new List<Claim>()
        {
            new Claim(ClaimsIdentity.DefaultNameClaimType, client.Login),
            new Claim(ClaimsIdentity.DefaultRoleClaimType, roleName!)
        };

        var claimsIdentity = new ClaimsIdentity(claims,
            "AplicationCookie",
            ClaimsIdentity.DefaultNameClaimType,
            ClaimsIdentity.DefaultRoleClaimType);

        return claimsIdentity;
    }

    public async Task<Guid> CreateClient(ClientDto dto)
    {
        _ = dto ?? throw new NotFoundException("ClientDto");

        var client = _clientMapper.ClientDtoToClient(dto);

        await _unitOfWork.ClientRepository.InsertOne(client);
        await _unitOfWork.Commit();

        return client.Id;
    }

    public async Task<ClientDto[]?> GetAllClients()
    {
        var clients = await _unitOfWork.ClientRepository.GetAll();

        var clientsDto = new ClientDto[clients.Count()];

        clients.ForEach(client =>
        {
            clientsDto[clients.IndexOf(client)] = _clientMapper.ClientToClientDto(client);
        });

        return clientsDto;
    }

    public async Task<ClientDto?> GetClientById(Guid id)
    {
        var client = await _unitOfWork.ClientRepository.FindBy(client => client.Id.Equals(id))
            .FirstOrDefaultAsync() ?? throw new NotFoundException("Client", id);

        var clientDto = _clientMapper.ClientToClientDto(client);

        return clientDto;
    }

    public async Task<ClientDto?> GetClientByLogin(string login)
    {
        var client = await _unitOfWork.ClientRepository.FindBy(client => client.Login.Equals(login))
            .FirstOrDefaultAsync() ?? throw new NotFoundException("Client", login);

        var clientDto = _clientMapper.ClientToClientDto(client);

        return clientDto;
    }

    public async Task<ClientDto> GetClientByRefreshToken(Guid refreshToken)
    {
        var user = await _mediator.Send(new GetUserByRefreshTokenQuery { RefreshTokenId = refreshToken });

        var dto = _clientMapper.ClientToClientDto(user);
        return dto;
    }

    public async Task<bool> IsAdmin(string email)
    {
        return (await _unitOfWork.ClientRepository.FindBy(client => client.Login.Equals(email))
            .FirstOrDefaultAsync())?.Role.Name.Equals("Admin") ?? false;
    }

    public async Task<bool> IsPasswordCorrect(string email, string password)
    {
        var currentPasswordHash = (await _unitOfWork.ClientRepository.FindBy(client => client.Login.Equals(email))
            .FirstOrDefaultAsync())?.PasswordHash;

        var enteredPasswordHash = GenerateMd5Hash(password);

        return currentPasswordHash?.Equals(enteredPasswordHash) ?? false;
    }

    public async Task<bool> IsUserExists(string email)
    {
        return await _unitOfWork.ClientRepository.FindBy(client => client.Login.Equals(email)).AnyAsync();
    }

    public async Task RegisterUser(ClientDto clientDto)
    {
        var clientRole = await _unitOfWork.RoleRepository.FindBy(role => role.Name.Equals("User")).FirstOrDefaultAsync();

        var client = new Client
        {
            Id = Guid.NewGuid(),
            Login = clientDto.Login,
            PasswordHash = GenerateMd5Hash(clientDto.PasswordHash),
            RoleId = clientDto.RoleId
        };

        await _unitOfWork.ClientRepository.InsertOne(client);

        await _unitOfWork.Commit();
    }

    private string GenerateMd5Hash(string input)
    {
        using (var md5 = MD5.Create())
        {
            var salt = _configuration["AppSettings:PasswordSalt"];
            var inputBytes = System.Text.Encoding.UTF8.GetBytes($"{input}{salt}");
            var hashBytes = md5.ComputeHash(inputBytes);

            return Convert.ToHexString(hashBytes);
        }
    }
}
