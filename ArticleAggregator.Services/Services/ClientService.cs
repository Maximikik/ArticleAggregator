using ArticleAggregator.Core.Dto;
using ArticleAggregator.Core.Models;
using ArticleAggregator.Data.CQS.Clients.Queries.GetClientById;
using ArticleAggregator.Data.CQS.Clients.Queries.GetClientByLogin;
using ArticleAggregator.Data.CQS.Clients.Queries.GetClientByRefreshToken;
using ArticleAggregator.Data.CQS.Clients.Queries.GetClientByRole;
using ArticleAggregator.Data.CustomExceptions;
using ArticleAggregator.Data.Entities;
using ArticleAggregator.Mapping;
using ArticleAggregator.Services.Interfaces;
using ArticleAggregator_Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.Security.Cryptography;

namespace ArticleAggregator.Services.Services;

public class ClientService(IUnitOfWork _unitOfWork,
                          IConfiguration _configuration,
                           IMapper _mapper,
                           IMediator _mediator) : IClientService
{
    public async Task<ClaimsIdentity> Authenticate(string userName)
    {
        var client = await _unitOfWork.ClientRepository
            .FindBy(login => login.Email.Equals(userName))
            .FirstOrDefaultAsync()
            ?? throw new NotFoundException("Client", userName);

        var roleName = (await _unitOfWork.RoleRepository.GetByIdAsNoTracking(client.RoleId))?.Name;

        var claims = new List<Claim>()
        {
            new Claim(ClaimsIdentity.DefaultNameClaimType, client.Email),
            new Claim(ClaimsIdentity.DefaultRoleClaimType, roleName!)
        };

        var claimsIdentity = new ClaimsIdentity(claims,
            "AplicationCookie",
            ClaimsIdentity.DefaultNameClaimType,
            ClaimsIdentity.DefaultRoleClaimType);

        return claimsIdentity;
    }

    //public async Task<Guid> CreateClient(ClientDto dto)
    //{
    //    _ = dto ?? throw new NotFoundException("ClientDto");

    //    var client = _clientMapper.ClientDtoToClient(dto);

    //    await _unitOfWork.ClientRepository.InsertOne(client);
    //    await _unitOfWork.Commit();

    //    return client.Id;
    //}

    public async Task RegisterUser(ClientDto clientDto)
    {
        var clientRole = await _unitOfWork.RoleRepository.FindBy(role => role.Name.Equals("User")).FirstOrDefaultAsync()
            ?? throw new Exception("rafals timoha");

        var client = new Client
        {
            Id = Guid.NewGuid(),
            Email = clientDto.Email,
            PasswordHash = GenerateMd5Hash(clientDto.PasswordHash),
            RoleId = clientDto.RoleId
        };

        await _unitOfWork.ClientRepository.InsertOne(client);

        if (clientRole.Clients != null)
        {
            clientRole.Clients.Add(client);
        }
        else
        {
            clientRole.Clients = [client];
        }

        await _unitOfWork.Commit();
    }

    public async Task DeleteClient(Guid id)
    {
        await _unitOfWork.ClientRepository.DeleteById(id);
        await _unitOfWork.Commit();
    }

    public async Task<ClientModel[]> GetAllClients()
    {
        var clients = await _unitOfWork.ClientRepository.GetAll();

        var clientsModel = new ClientModel[clients.Count()];

        clients.ForEach(client =>
        {
            clientsModel[clients.IndexOf(client)] = _mapper.Map<Client, ClientModel>(client);
        });

        return clientsModel;
    }

    public async Task<ClientModel[]> GetClientsByRole(string roleName)
    {
        var request = new GetClientsByRoleQuery { roleName = roleName };
        var client = await _mediator.Send(request);

        var clientModel = client.Select(_mapper.Map<Client, ClientModel>).ToArray();

        return clientModel;
    }

    public async Task<ClientModel> GetClientById(Guid id)
    {
        var client = await _mediator.Send(new GetClientByIdQuery { Id = id })
            ?? throw new NotFoundException("Client", id);

        var clientModel = _mapper.Map<Client, ClientModel>(client);

        return clientModel;
    }

    public async Task<ClientModel> GetClientByLogin(string login)
    {
        var client = await _mediator.Send(new GetClientByLoginQuery { Login = login })
            ?? throw new NotFoundException("Client", login);

        var clientModel = _mapper.Map<Client, ClientModel>(client);

        return clientModel;
    }

    public async Task<ClientModel> GetClientByRefreshToken(Guid refreshToken)
    {
        var user = await _mediator.Send(new GetClientByRefreshTokenQuery { RefreshTokenId = refreshToken });

        var clientModel = _mapper.Map<Client, ClientModel>(user);
        return clientModel;
    }

    public async Task<bool> IsAdmin(string email)
    {
        return (await _unitOfWork.ClientRepository.FindBy(client => client.Email.Equals(email))
            .FirstOrDefaultAsync())?.Role.Name.Equals("Admin") ?? false;
    }

    public async Task<bool> IsPasswordCorrect(string email, string password)
    {
        var currentPasswordHash = (await _unitOfWork.ClientRepository.FindBy(client => client.Email.Equals(email))
            .FirstOrDefaultAsync())?.PasswordHash;

        var enteredPasswordHash = GenerateMd5Hash(password);

        return currentPasswordHash?.Equals(enteredPasswordHash) ?? false;
    }

    public async Task<bool> IsUserExists(string email)
    {
        return await _unitOfWork.ClientRepository.FindBy(client => client.Email.Equals(email)).AnyAsync();
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